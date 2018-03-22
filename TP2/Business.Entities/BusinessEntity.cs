using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
        /*Esta clase contendrá los elementos básicos que compartirán las
         * entidades de nuestro sistema y luego heredarán de ella.*/
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }

        private int _id;
        private States _state;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public States State
        {
            get { return _state; }
            set { _state = value; }
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        } 
    }
}
