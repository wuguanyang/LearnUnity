

namespace EnjoyMoment.Test.Dispatcher {
    using EnjoyMoment;

    public enum TestEventID { 
        Switch,
    }

    public class TestDispatcher : EventBase<TestDispatcher,string, TestEventID> {
        
    }
}

