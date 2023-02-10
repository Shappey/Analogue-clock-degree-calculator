using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Hierarchical_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a hierarchical structure");
            Structure newStruct = new Structure();
            newStruct.insertBranch(1);
            newStruct.insertBranch(2);
            newStruct.insertBranch(3);
            newStruct.insertBranch(4);
            newStruct.insertIntoBranch(21, 2);
            newStruct.insertIntoBranch(22, 2);
            newStruct.insertIntoBranch(31, 3);
            newStruct.insertIntoBranch(41, 4);
            newStruct.insertIntoBranch(42, 4);
/*            newStruct.insertIntoBranch(99, 21);
            newStruct.insertIntoBranch(55, 31);
            newStruct.insertIntoBranch(100, 55);*/
            newStruct.getResult();
            Console.WriteLine("\nThis structures depth is: ");
            newStruct.getDepth(newStruct.firstBranch);
            Console.WriteLine(newStruct.depth);
            Console.ReadLine();
        }
    }

    class Branch
    {
        public int Value;
        List<Branch> branches;

        public Branch()
        {
            this.branches = new List<Branch>();
        }

        public List<Branch> getBranches()
        {
            return branches;
        }
        public void addBranches(Branch newBranch) 
        { 
            branches.Add(newBranch);
        }
    }

    class Structure
    {
        public Branch firstBranch = new Branch();
        public int depth = 0;
        //temp_depth starts at 1 because of the first branch being in level 1
        public int temp_depth = 1;
        //not a great implementation to stop recursion function
        public bool loopStopper = false;
        public Structure()
        {
            firstBranch.Value = 0;
        }
        //Function to insert the main branch nodes starting from the root
        public void insertBranch(int x)
        {
            Branch newBranch = new Branch();
            newBranch.Value = x;
            firstBranch.addBranches(newBranch);
        }
        //Function that finds the exact branch with the matching value
        public Branch findBranchValue (int value, Branch branch)
        {
            Branch test = null;
            for (var i = 0; i < branch.getBranches().Count && !loopStopper; i++)
            {
                test = branch.getBranches()[i];
                if (test.Value == value)
                {
                    // Returns the matching branch
                    loopStopper = true;
                    return test;
                }
                else
                {
                    //recursion
                    findBranchValue(value, test);
                }
            }
            return test;
        }
        //Function to insert new branches into existing nodes
        public void insertIntoBranch(int newValue, int destinationBranchValue)
        {
            loopStopper= false;
            Branch destinationBranch = findBranchValue(destinationBranchValue, firstBranch);
            if (destinationBranch != null)
            {
                Branch newBranch = new Branch();
                newBranch.Value = newValue;
                destinationBranch.addBranches(newBranch);
                Console.WriteLine("Branch added succesfully");
            }
            else
            {
                Console.WriteLine("The branch with the value: " + destinationBranchValue +" does not exist!");
            };
        }
        public void getDepth(Branch branch)
        {

            for (var i = 0; i < branch.getBranches().Count; i++)
            {
                Branch test = branch.getBranches()[i];

                if (test.getBranches().Count == 0)
                {
                    if(temp_depth > depth)
                    {
                        depth = temp_depth;
                    }
                    if (branch.getBranches().Count == i + 1)
                    {
                        temp_depth -= 1;
                    }
                    else
                    {
                       // temp_depth++;
                    }
                }
                else
                {
                    //recursion
                    temp_depth++;
                    getDepth(test);
                }
            }
        }


        //Print out the current structure
        public void getResult()
        {
            Console.WriteLine(firstBranch.Value);
            string space = "";
            for (var i = 0; i < firstBranch.getBranches().Count; i++)
            {
                Branch test = firstBranch.getBranches()[i];
                Console.WriteLine(firstBranch.getBranches()[i].Value);
                foreach (var Branch in test.getBranches())
                {
                    Console.WriteLine(Branch.Value);
                };
                space = space + " ";
                Console.Write(space);
            }
        }
    }


}