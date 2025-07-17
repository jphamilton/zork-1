using Zork1.Library;
using Zork1.Library.Utilities;

namespace Tests.Utilities;
public class PickOneTests
{
    [Fact]
    public void should_not_pick_same_message_more_than_once()
    {
        void Run()
        {
            List<string> picked = [];

            for (int i = 0; i < 4; i++)
            {
                var msg = Tables.Hop.Pick();
                Assert.DoesNotContain(msg, picked);
            }
        }
        
        for (int i = 0; i < 100; i++)
        {
            Run();
        }
    }
}
