using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AILib.RL
{
    public class QMatrix
    {
        private uint numOfStates;
        private uint numOfActions;
        public double[,] matrix;
        public double[,] hitMatrix;

        public QMatrix(uint numOfStates, uint numOfActions)
        {
            if(numOfStates <= 0 || numOfActions <= 0)
            {
                throw new ArgumentException("Number of states and actions must be greater than 0.");
            }
            this.numOfStates = numOfStates;
            this.numOfActions = numOfActions;
            matrix = new double[numOfStates, numOfActions];
            hitMatrix = new double[numOfStates, numOfActions];
        }

        public void UpdateQMatrix(double reward, uint currentState, uint currentAction, double learningRate)
        {
                matrix[currentState, currentAction] = (1.0 - learningRate) * matrix[currentState, currentAction] + reward * learningRate;
                hitMatrix[currentState, currentAction]++;
        }

    }
}
