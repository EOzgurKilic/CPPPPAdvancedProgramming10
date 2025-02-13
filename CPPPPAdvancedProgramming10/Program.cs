using System.Net.Http.Headers;
using static CPPPPAdvancedProgramming10.Program;

namespace CPPPPAdvancedProgramming10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Delegates
            //They are the architecure which allows us to reference, keep methods as data. Kinda the representations of methods
            //For callbacks and event-based programming, we utilize from delegates.
            //Delegates make methods arguments for different methods and call them.
            //Calling methods via delegates is a dynamic runtime action.
            //In its common usage, they are to allow specializing objects' behaviours.
            //E.g. imagine you have a class preparing meals;
            //You utilize from delegates if you want to make a customizable qualification about how the meal will be prepared from developers' aspects possible.

            //Declaration
            //Syntax Prototype : *AccessModifier delegate *MethodSignature
            //For an instance : public delegate void ExpDelegateHandler(int a, string b);
            //Now, our example delegate can represent void methods with two parameters in the order one is int and the other string. 
            //According to terminology, we should end the names of delegates in the proper way with "Handler".

            //How to represent a method with a delegate
            //You gotta create an instance of the used delegate. Delegates are actually reference type variables steming from System.Delegate class.
            //In fact, we create a class whenever a delegate is declared.
            //Lets think about our example delegate we declared above;
            //public delegate void ExpDelegateHandler(int a, string b);
            //ExpDelegateHandler ExpDelegate1 = new ExpDelegateHandler(*ConvenientMethodName); or ExpDelegateHandler ExpDelegate1 = *ConvenientMethodName;
            //There is two other way done with Lambda Expressions and anonymous method feature steming from Anonymous Types subject.
            //These two will be illustrated here after they are covered in the following tutorials!!!
            ExpDelegateHandler ExpDelegate1 = new ExpDelegateHandler(A.ExpMethod1); 
            ExpDelegateHandler ExpDelegate2 = A.ExpMethod1;
            //In the second declaration, we leave the instantiation to the compiler.

            //How to use a method represented by a delegate
            //Literally the same while calling a method can be done to call a method over a delegate.
            ExpDelegate1(10,"Ahmet"); //This action automatically calls the invoke method from Delegate class which can be done manually. Check the line below.
            ExpDelegate1.Invoke(15,"Ahmet");


            //Multicast Delegates
            //Delegates can represent multiple methods as long as the methods are proper for the delegates' signeture.
            //Here is an example about its declaration;
            ExpDelegateHandler2 ExpDelegate3 = A.ExpMethod2;
            ExpDelegate3 += A.ExpMethod3;
            ExpDelegate3 += A.ExpMethod4;
            ExpDelegate3 += A.ExpMethod5;

            //Or you can create 4 delegates and assign each method to each of them and then gather them up in a single delegate;

            /*ExpDelegateHandler2 ExpDelegate4 = A.ExpMethod2;
            ExpDelegateHandler2 ExpDelegate5 = A.ExpMethod3;
            ExpDelegateHandler2 ExpDelegate6 = A.ExpMethod4;
            ExpDelegateHandler2 ExpDelegate7 = A.ExpMethod5;
            ExpDelegateHandler2 ExpDelegateCollab = ExpDelegate4 + ExpDelegate5 + ExpDelegate6 + ExpDelegate7;*/
            //It will print the CW methods inside the methods respectively based on the assignment order of the methods.

            //You can remove methods from delegates as well as you can add 'em.
            ExpDelegate3();
            Console.WriteLine("--------------------");
            ExpDelegate3 -= A.ExpMethod4;
            ExpDelegate3();
            ExpDelegate3 += A.ExpMethod4;

            //It is also possible to get all the methods a delegate represents as a delegate array.
            var MethodList = ExpDelegate3.GetInvocationList();
            foreach (var Method in MethodList) 
            {
                Console.WriteLine(Method.Method.Name);
            }

            //As the methods utilize from generics, delegates do the same.
            ExpGenericDelegateHandler<int, string> ExpGenericDelegate = new ExpGenericDelegateHandler<int, string>(A.ExpGenericMethod<int, string>);
            ExpGenericDelegateHandler<int, string> ExpGenericDelegate1 = A.ExpGenericMethod<int, string>;

        }
    public delegate void ExpDelegateHandler(int a, string b);
    public delegate void ExpDelegateHandler2();
    public delegate td2 ExpGenericDelegateHandler<td1,td2>(td2 t2FieldArg);
        
}
    class A {
        public static void ExpMethod1(int a, string b) { Console.WriteLine($"The given argument: {a}, {b}");}
        public static void ExpMethod2(){Console.WriteLine("First method");} 
        public static void ExpMethod3(){Console.WriteLine("Second method");} 
        public static void ExpMethod4(){Console.WriteLine("Third method");} 
        public static void ExpMethod5(){Console.WriteLine("Fourth method");} 
        public static t2 ExpGenericMethod<t1,t2>(t2 t2Field){
            Console.WriteLine($"Generic method {t2Field}"); 
            return t2Field; 
        }
        

        //A lil bit questionings about generics - unrelated to the tutorial
        /*public static int? EMethod<t1, t2>(t2 t2Field)
        {
            if (t2Field is int x) { return x;}
            return -1;
        }*/
    }
}
