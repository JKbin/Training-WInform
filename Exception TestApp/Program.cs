using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exception_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 10, value = 0;
           


            Console.WriteLine($"value = {value}");

            try
            {
                value = x / y;
                Console.WriteLine($"{x} / {y} = {value}");                  //에러가 발생할 수 있는 부분을 적는다.
                //throw new Exception("1. 사용자에러");
            }

            catch(DivideByZeroException ex)                                 // 이게 실행되면 3은 실행할 필요가 없다.
            {
                Console.WriteLine("2. y의 값을 0보다 크게 입력하세요");
            }

            catch (Exception ex)            //catch는 에러가 났을 때 어째해야하나?      // 이 구문의 위치는 맨 마지막 finally위에 있어야한다.
            {   
                Console.WriteLine("3. " + ex.Message);
                //Console.WriteLine("y의 값을 0보다 크게 입력하세요");        // 에러가 발생했을 때 이 메세지가 출력된다.

            }
            finally
            {
                Console.WriteLine("4. 프로그램이 종료했습니다");          //에러가 났든 안났든 빌딩이 끝나면 무조건 (finally)
                
            }                                                             // 순서는 try > catch > finally
        }

    }
}
