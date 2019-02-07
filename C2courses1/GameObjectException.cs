using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2courses1
{

    /// <summary>
    /// Исключение объекта игры
    /// </summary>

    class GameObjectException: Exception
    {
        public GameObjectException(string message) : base(message)
        {

        }   
        
    }
}
