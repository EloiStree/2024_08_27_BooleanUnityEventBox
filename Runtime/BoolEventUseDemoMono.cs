using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Eloi.BoolEvent.Relay;



public class BoolEventUseDemoMono : MonoBehaviour{


    [Header("On changed demo")]
    public Eloi.BoolEvent.Changed.OnTrueFalseValueChanged m_onTrueFalseValueChanged;
    public Eloi.BoolEvent.Changed.OnTrueFalseChanged m_onTrueFalseChanged;
    public Eloi.BoolEvent.Changed.OnValueChanged m_onValueChanged;
    public Eloi.BoolEvent.Changed.OnInverseChanged m_onInverseChanged;

    [Header("On relay demo")]
    public Eloi.BoolEvent.Relay.OnTrueFalseValueRelayed m_onTrueFalseValueRelayed;
    public Eloi.BoolEvent.Relay.OnTrueFalseRelayed m_onTrueFalseRelayed;
    public Eloi.BoolEvent.Relay.OnValueRelayed m_onValueRelayed;
    public Eloi.BoolEvent.Relay.OnInverseRelayed m_onInverseRelayed;


    [Header("Bean")]
    public Eloi.BoolEvent.Bean.ObservedBooleanValue m_boolEventBean;
}


namespace Eloi
{

    public static partial class BoolEvent {


        public static partial class Bean {


        }


        public static class Changed {

            public class OnInverseChanged : AbstractBoolEventOnChanged
            {
                public UnityEvent<bool> m_onChanged;
                public UnityEvent<bool> m_onChangedInverse;


                public override void OnChanged(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                    m_onChangedInverse.Invoke(!newValue);
                }
            }
            public class OnTrueFalseValueChanged : AbstractBoolEventOnChanged
            {
                public UnityEvent<bool> m_onChanged;
                public UnityEvent m_onTrue;
                public UnityEvent m_onFalse;

                public override void OnChanged(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                    if (newValue)
                        m_onTrue.Invoke();
                    else
                        m_onFalse.Invoke();
                }
            }
            public class OnTrueFalseChanged : AbstractBoolEventOnChanged
            {
                public UnityEvent m_onTrue;
                public UnityEvent m_onFalse;

                public override void OnChanged(bool newValue)
                {
                    if (newValue)
                        m_onTrue.Invoke();
                    else
                        m_onFalse.Invoke();
                }
            }
            public class OnValueChanged : AbstractBoolEventOnChanged
            {
                public UnityEvent<bool> m_onChanged;

                public override void OnChanged(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                }
            }
            public abstract class AbstractBoolEventOnChanged
            {
                /// <summary>
                /// Current Value received with Set
                /// </summary>
                bool m_currentValue;

                /// <summary>
                /// Previous Value received with from the last set
                /// </summary>
                bool m_previousValue;

                /// <summary>
                /// Will Invoke the Unity Event of the class
                /// </summary>
                /// <param name="value"></param>
                public void Invoke(bool value)
                {
                    m_previousValue = m_currentValue;
                    m_currentValue = value;
                    if (m_previousValue != m_currentValue)
                        OnChanged(value);
                }


                public AbstractBoolEventOnChanged()
                {
                    m_currentValue = false;
                    m_previousValue = false;
                }
                public AbstractBoolEventOnChanged(bool value)
                {
                    m_currentValue = value;
                    m_previousValue = value;
                }
                public AbstractBoolEventOnChanged(bool previousValue, bool currentValue)
                {
                    m_currentValue = currentValue;
                    m_previousValue = previousValue;
                }

                public void SetWithoutNotification(bool previousValue, bool currentValue)
                {
                    m_previousValue = previousValue;
                    m_currentValue = currentValue;
                }



                public void GetCurrentValue(out bool value)
                {
                    value = m_currentValue;
                }
                public void GetPreviousValue(out bool value)
                {
                    value = m_previousValue;
                }
                public void GetValues(out bool previousValue, out bool currentValue)
                {
                    previousValue = m_previousValue;
                    currentValue = m_currentValue;
                }
                public void InvokeWithCurrent()
                {
                   Invoke(m_currentValue);
                }
                public abstract void OnChanged(bool newValue);
            }

        }



        public static class Relay {


            public class OnInverseRelayed : AbstractBoolEventOnRelayed
            {
                public UnityEvent<bool> m_onChanged;
                public UnityEvent<bool> m_onChangedInverse;
            

                public override void OnRelay(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                    m_onChangedInverse.Invoke(!newValue);
                }
            }

            public class OnTrueFalseValueRelayed : AbstractBoolEventOnRelayed
            {
                public UnityEvent<bool> m_onChanged;
                public UnityEvent m_onTrue;
                public UnityEvent m_onFalse;

                public override void OnRelay(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                    if (newValue)
                        m_onTrue.Invoke();
                    else
                        m_onFalse.Invoke();
                }
            }
            public class OnTrueFalseRelayed : AbstractBoolEventOnRelayed
            {
                public UnityEvent m_onTrue;
                public UnityEvent m_onFalse;

                public override void OnRelay(bool newValue)
                {
                    if (newValue)
                        m_onTrue.Invoke();
                    else
                        m_onFalse.Invoke();
                }
            }
            public class OnValueRelayed : AbstractBoolEventOnRelayed
            {
                public UnityEvent<bool> m_onChanged;

                public override void OnRelay(bool newValue)
                {
                    m_onChanged.Invoke(newValue);
                }
            }
            public abstract class AbstractBoolEventOnRelayed
            {
                /// <summary>
                /// Current Value received with Set
                /// </summary>
                bool m_currentValue;

               
                public void Invoke(bool value)
                {
                    m_currentValue = value;
                    OnRelay(value);
                }

                public AbstractBoolEventOnRelayed()
                {
                    m_currentValue = false;
                }
                public AbstractBoolEventOnRelayed(bool value)
                {
                    m_currentValue = value;
                }
               

                public void SetWithoutNotification(bool value)
                {
                    m_currentValue = value;
                }



                public void GetCurrentValue(out bool value)
                {
                    value = m_currentValue;
                }
               
               
                public void InvokeWithCurrent()
                {
                    Invoke(m_currentValue);
                }
                /// <summary>
                /// I am a methode that call the event to relay a value that has been set even if it is the same value
                /// </summary>
                /// <param name="newValue"></param>
                public abstract void OnRelay(bool newValue);
            }
        }
    }



}