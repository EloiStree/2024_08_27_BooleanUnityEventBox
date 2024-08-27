using UnityEngine;


namespace Eloi
{

    public static partial class BoolEvent {


        public static partial class Bean {

            /// <summary>
            /// I am a class that allows to observed a boolean for change without direct event.
            /// I am here just to check the state of a boolean and if it changed since last time.
            /// </summary>
            [System.Serializable]
            public class BooleanObservedForChange
            {

                [SerializeField] bool m_booleanState;
                public void SetBoolean(in bool value, out bool changed)
                {
                    changed = value != m_booleanState;
                    m_booleanState = value;
                }
                public void GetCurrentValue(out bool value) => value = m_booleanState;
                public bool GetCurrentValue()
                {
                    return m_booleanState;
                }

            }


            


        }
    }



}