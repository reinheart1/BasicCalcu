using System;

namespace BasicCalcu.Models
{
    // Base class for mathematical operations
    public abstract class Operation
    {
        public abstract double Compute(double num1, double num2);
    }

    // Derived classes for specific operations
    public class Addition : Operation
    {
        public override double Compute(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Subtraction : Operation
    {
        public override double Compute(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Multiplication : Operation
    {
        public override double Compute(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Division : Operation
    {
        public override double Compute(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");

            return num1 / num2;
        }
    }

  
    public class Calculator
    {
        public double Compute(double num1, double num2, string operation)
        {
            Operation op;

            switch (operation)
            {
                case "Add":
                    op = new Addition();
                    break;
                case "Subtract":
                    op = new Subtraction();
                    break;
                case "Multiply":
                    op = new Multiplication();
                    break;
                case "Divide":
                    op = new Division();
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }

          
            return op.Compute(num1, num2);
        }
    }
}
