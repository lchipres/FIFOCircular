using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
    class Processor
    {
        static private Random r = new Random();
        int _emptyCicles = 0, _completedTasks = 0, _uncompletedTasks = 0, _ciclesUncompleted = 0;
        Task first;

        public void process()
        {
            for (int i = 0; i < 300; i++)//300 cicles
            {
                randomTask();
                if (first != null)//There is a task to work
                {
                    if (first._cicles > 0)
                    {
                        first._cicles--;//Minus 1 cicle to task
                    }
                    else
                    {
                        _completedTasks++;//First.cicle=0? then add 1 to completed task
                        first = first.next;//go for the next
                    }
                }
                else
                {
                    _emptyCicles++;//Isn't a task then add 1 to empty cicles
                }
            }
            uncompletedTasks();//After doing 300 cicles count how much tasks where uncompleted
        }
        private void randomTask()
        {
            if (r.Next(1, 101) < 36)//35% probability
            {
                Task helper = new Task();
                helper._cicles = numberCicles();//Adding random number of cicles
                addTask(helper);//Adding the task
            }//Add a random task

        }

        private void addTask(Task t)//Function to add a task
        {
            if (first == null)
            {
                first = t;
                first.next = first;
            }
            else
            {
                add(first, t);
            }
        }

        private void add(Task place, Task t)//recursive function to add a task
        {
            if (place.next == first)
            {
                place.next = t;
                place.next = first;
            }
            else
            {
                add(place.next, t);
            }
        }

        private int numberCicles()//How much cicles?
        {
            int cicles;
            cicles = r.Next(4, 15);
            return cicles;
        }

        private void uncompletedTasks()//How much uncompleted tasks?
        {
            Task helper = first;
            if (helper != null)
            {
                while (helper.next._cicles == 0||helper.next!=first)//Do until get a cicles!=0
                {
                    _uncompletedTasks++;
                    helper = helper.next;
                }
                _uncompletedTasks++;
            }
        }

        public int getEmptyCicles()
        {
            return _emptyCicles;
        }

        public int getUncompletedTasks()
        {
            return _uncompletedTasks;
        }

        public int getCompletedTasks()
        {
            return _completedTasks;
        }
    }
}
