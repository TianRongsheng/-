using System;

namespace SimpleExceptions
{
    class Program
    {
        static void Main()
        {

            while (true)
            {

                try
                {
                    string userInput;
                    //输入
                    Console.Write("Input a number between 0 and 5 or just hit return to exit)> ");
                    userInput = Console.ReadLine();
                    //1.输入内容是空串
                    if (string.IsNullOrEmpty(userInput))
                    {
                        break;
                    }
                    //2.试图做字符串数字转换
                    //--有可能引发FormatException 
                    //--有可能引发OverflowException
                    int index = Convert.ToInt32(userInput);

                    //3.输入范围有可能引发异常IndexOutOfRangeException
                    if (index < 0 || index > 5)
                    {
                        throw new IndexOutOfRangeException($"You typed in {userInput}");
                    }

                    Console.WriteLine($"Your number was {index}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception: Number should be between 0 and 5. {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"An exception was thrown. Message was格式错误+{ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"An exception was thrown. Message was:溢出");
                }
                finally
                {
                    Console.WriteLine("Thank you\n");
                }
            }
        }
    }
}
