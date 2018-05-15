using System.Runtime.Serialization;
using System.ServiceModel;

namespace Foobar_service
{
    [ServiceContract]
    public interface IFoo
    {
        [OperationContract]
        Bar GetBar();

        [OperationContract]
        void SetBar(Bar bar);
    }

    [DataContract]
    public class Bar
    {
        public Bar(int bar)
        {
            this.bar = bar;
        }

        [DataMember]
        public int bar
        {
            get;
            set;
        }
    }
}