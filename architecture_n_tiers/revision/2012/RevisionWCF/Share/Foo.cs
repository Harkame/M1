using FoobarService;

namespace Foobarservice
{
    public class Foo : IFoo
    {
        private Bar bar;

        public Foo()
        {
            bar = new Bar(0);
        }
        public Bar GetBar()
        {
            return bar;
        }
        public void SetBar(Bar bar)
        {
            this.bar = bar;
        }
    }
}