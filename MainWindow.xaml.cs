using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace WpfTips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Test();
        }

       

        public void Test()
        {

            Predicate<int> isA = i => i < 5;
            Predicate<int> isB = i => i > 5 && i < 10;
            Predicate<int> isC = i => i > 10 && i < 20;
            Predicate<int> isD = i => i > 20;
            Predicate<int> isAorB = i => isA(i) || isB(i);
            Predicate<int> isCorD = i => isC(i) || isD(i);
            int[] nums = new[] { 2, 29, 3, 9, 1, 18, 19, 8, 23};
            nums.ToList().ForEach(x => Trace.WriteLine(x));
            int index = Sort(nums, 0, nums.Length - 1, isAorB, isCorD);
            Trace.WriteLine(index);
            Trace.WriteLine("--------------------------");
            nums.ToList().ForEach(x => Trace.WriteLine(x));
            Trace.WriteLine("--------------------------");
            Sort(nums, index, nums.Length - 1, isC, isD);
            Sort(nums, 0, index - 1, isA, isB);
            Trace.WriteLine("--------------------------");
            nums.ToList().ForEach(x => Trace.WriteLine(x));
        }

        private int Sort(int[] nums, int start, int end, Predicate<int> isFirstGroup, Predicate<int> isSecondGroup)
        {


            int a = start;
            int j = end;

            while (a < j)
            {
                int leftNo = nums[a];
                int rightNo = nums[j];

                if (isFirstGroup(leftNo))
                {
                    a++;
                }
                else
                {
                    if (isSecondGroup(rightNo))
                    {
                        j--;
                    }
                    else
                    {
                        nums[a] = rightNo;
                        nums[j] = leftNo;
                        a++;
                        j--;
                    }
                }
            }

            return a;
        }
    }
}
