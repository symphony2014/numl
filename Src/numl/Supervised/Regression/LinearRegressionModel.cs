﻿using System;
using System.Linq;
using numl.Math.LinearAlgebra;
using System.Collections.Generic;

namespace numl.Supervised.Regression
{
    /// <summary>
    /// Linear Regression model
    /// </summary>
    public class LinearRegressionModel : Model
    {
        /// <summary>
        /// Theta parameters vector mapping X to y.
        /// </summary>
        public Vector Theta { get; set; }

        /// <summary>
        /// Initialises a new LinearRegressionModel object
        /// </summary>
        public LinearRegressionModel() { }

        /// <summary>
        /// Create a prediction based on the learned Theta values and the supplied test item.
        /// </summary>
        /// <param name="x">Training record</param>
        /// <returns></returns>
        public override double Predict(Vector x)
        {
            Vector xCopy = (this.NormalizeFeatures ?
                                this.Normalizer.Normalize(x, this.Summary)
                                : x);

            return xCopy.Insert(0, 1.0, false).Dot(Theta);
        }
    }
}
