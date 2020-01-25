using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API
{
    public static class TestModule
    {
        /// <summary>
        /// The assumption is that the module seeks to process 1, 2, 3+, 1.0 and returns any other value unprocessed
        /// I asumme a logical error on the basis that input 1 shoud return one while input 2 and 3 are doubled and tripled respectively. 1.0f is treated as a special case while other values are returned as is 
        /// Case 1 has no operation.
        /// The implication is that input 1 falls through and is processed by case 2
        /// The solution is to provide an operation for case 1. The operation will only return 1 for input 1
        /// With this done, the Module method has specific implementations for processing inputs 1, 2, 3+ and 1.0 differently while any other value is returned unprocessed
        /// The VogCodeChallenge.Test module contains a number of test cases to support my assumption and implementation
        /// </summary>
        /// <param name="testObject">input value to process</param>
        /// <returns>returns result after processing</returns>
        public static object Module(object testObject)
        {
            switch (testObject)
            {
                case 1:
                    return 1; // implementation should be provided for this case to return 1
                case 2:
                    return doubler((int)testObject);
                case int value when value >= 3:
                    return tripler(value);
                case float floatValue when floatValue == 1.0f:
                    return leveler(floatValue);
                default:
                    return testObject;

            }

            int doubler(int amount) => amount * 2;
            int tripler(int amount) => amount * 3;
            double leveler(double amount) => amount - 0.1f * 10f;
        }
    }
}
