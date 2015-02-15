using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Transactions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using iPromise.BusinessLogics;

namespace iPromise.DataServices
{
    public class Dataservice
    {
        private static readonly Func<IDataRecord, string, DateTime?> GetNullableDateTime = (record, name) => record.GetDateTime(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, int?> GetNullableInt16 = (record, name) => record.GetInt16(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, int?> GetNullableInt32 = (record, name) => record.GetInt32(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, string> GetString = (record, name) => record.GetString(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, double?> GetNullableDouble = (record, name) => record.GetDouble(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, bool> GetBool = (record, name) => record.GetBoolean(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, short> GetInt16 = (record, name) => record.GetInt16(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, int> GetInt32 = (record, name) => record.GetInt32(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, DateTime> GetDateTime = (record, name) => record.GetDateTime(record.GetOrdinal(name));
        private static readonly Func<IDataRecord, string, decimal> GetDecimal = (record, name) => record.GetDecimal(record.GetOrdinal(name));
        

        private readonly Database _database;

        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        public Dataservice()
        {
            _database = factory.Create("iPromise");//DatabaseFactory.CreateDatabase();
        }

       
        public int CreateEvent(Event _event)
        {
            if (_event == null)
                throw new ArgumentException("Event");

            using (DbCommand command = _database.GetStoredProcCommand("[dbo].[usp_CreateEvent]"))
            {
                _database.AddInParameter(command, "@Event_Name", DbType.String, _event.Name);
                _database.AddInParameter(command, "@Event_Description", DbType.String, _event.Description);
                _database.AddInParameter(command, "@Event_Location", DbType.String, _event.Location);                
                _database.AddInParameter(command, "@Event_Date", DbType.DateTime, _event.Date);
              //  _database.AddInParameter(command, "@Event_Time", DbType.DateTime, _event.Time);               
             //   _database.ExecuteScalar(command);
                return Convert.ToInt32(_database.ExecuteScalar(command));
            }
        }

        public IList<Event> EventsAllGet() 
        {
            var _events = new List<Event>();

        
         using (DbCommand command = _database.GetStoredProcCommand("[dbo].[EventsGetAll]"))
            {
                using (IDataReader reader = _database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        _events.Add(new Event
                        {//     DateEdited = reader.GetDefaultIfDBNull("Date_edited", GetNullableDateTime, null),
                               event_id =   reader.GetDefaultIfDBNull("event_id", GetInt32, 0),
                               Name = reader.GetDefaultIfDBNull("event_name", GetString,null),
                               Description = reader.GetDefaultIfDBNull("event_description", GetString, null),
                               Location = reader.GetDefaultIfDBNull("event_location", GetString, null),
                               Date = reader.GetDefaultIfDBNull("event_start_datetime", GetNullableDateTime, null),
                               DateCreated = reader.GetDefaultIfDBNull("event_create_datetime", GetNullableDateTime, null),
                               //Time = reader.GetDateTime(10),
                            });
                    }

                }
             }
         return _events;

          }

        public void CreateContact(Contact _contact)
        {
            using (DbCommand command = _database.GetStoredProcCommand("[dbo].[usp_CreateContact]"))
            {
                _database.AddInParameter(command, "@firstname", DbType.String, _contact.firstname);
                _database.AddInParameter(command, "@middleinitial", DbType.String, _contact.middleInitial);
                _database.AddInParameter(command, "@lastname", DbType.String, _contact.lastname);
                _database.AddInParameter(command, "@email", DbType.String, _contact.email);                
                _database.ExecuteScalar(command);
            }

        }

        protected int PostQuestion(Question _question)
        {
            using (DbCommand command = _database.GetStoredProcCommand("[dbo].[usp_CreateQuestion]"))
            {
                _database.AddInParameter(command, "@question", DbType.String, _question.question_description);                              
                return Convert.ToInt32(_database.ExecuteScalar(command));
            }

        }

        public void PostQuestionToEvent(Question _question, int event_id)
        {
            var _questionId = this.PostQuestion(_question);                        
            //int event_id, int question_id
            using (DbCommand command = _database.GetStoredProcCommand("[dbo].[PostQuestionToEvent]"))
            {
                _database.AddInParameter(command, "@event_id", DbType.Int16, event_id);
                _database.AddInParameter(command, "@question_id", DbType.Int16, _questionId);
                _database.ExecuteScalar(command);
            }
        }

    }
}