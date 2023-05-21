using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmitBytesBlog.Entity
{
    public abstract class EntityBase
    {


        [BsonIgnore]
        public abstract string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CreatedBy { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedOn { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UpdatedBy { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedOn { get; set; }

        public int VersionNo { get; set; }
        public bool IsActive { get; set; }

        [BsonIgnore]
        public string NewObjectId
        {
            get { return ObjectId.GenerateNewId().ToString(); }
        }

    }
}
