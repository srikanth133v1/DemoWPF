using System.Runtime.Serialization;

namespace DemoCalculatorClient.Model
{
    /// <summary>
    /// Operation model representing an equation
    /// </summary>
    [DataContract]
    public class Operation
    {
        [DataMember(Name = "parm1")]
        public double Left { get; set; }

        [DataMember(Name = "parm2")]
        public double Right { get; set; }

        [DataMember(Name = "op")]
        public string Operator { get; set; }

        public double Result { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} = {3}",
                Left, Operator, Right, Result);
        }
    }
}
