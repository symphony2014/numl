﻿using System;
using System.Linq;
using numl.Math.LinearAlgebra;
using System.Collections.Generic;

namespace numl.Math.Functions.Regularization
{
    /// <summary>
    /// Standard regularization
    /// </summary>
    public class L2Regularizer : IRegularizer
    {
        /// <summary>
        /// Applies regularization to the current cost
        /// </summary>
        /// <param name="j">Current cost</param>
        /// <param name="theta">Current theta</param>
        /// <param name="m">Training records</param>
        /// <param name="lambda">Regularization constant</param>
        /// <returns></returns>
        public double Regularize(double j, Vector theta, int m, double lambda)
        {
            if (lambda != 0)
            {
                j = ((lambda / (2.0 * m)) * (new Vector(theta.Skip(1).ToArray()) ^ 2.0).Sum()) + j;
            }
            return j;
        }

        /// <summary>
        /// Applies regularization to the current gradient
        /// </summary>
        /// <param name="theta">Current theta</param>
        /// <param name="gradient">Current gradient</param>
        /// <param name="m">Training records</param>
        /// <param name="lambda">Regularization constant</param>
        public Vector Regularize(Vector theta, Vector gradient, int m, double lambda)
        {
            if (lambda != 0)
            {
                for (int i = 1; i < theta.Length; i++)
                {
                    gradient[i] = gradient[i] + ((lambda / m) * theta[i]);
                }
            }
            return gradient;
        }
    }
}
