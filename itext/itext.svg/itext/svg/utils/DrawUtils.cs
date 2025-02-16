/*
This file is part of the iText (R) project.
Copyright (c) 1998-2025 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Svg;

namespace iText.Svg.Utils {
    /// <summary>
    /// Utility class for drowing shapes on
    /// <see cref="iText.Kernel.Pdf.Canvas.PdfCanvas"/>
    /// </summary>
    public class DrawUtils {
        private DrawUtils() {
        }

        /// <summary>
        /// Draw an arc on the passed canvas,
        /// enclosed by the rectangle for which two opposite corners are specified.
        /// </summary>
        /// <remarks>
        /// Draw an arc on the passed canvas,
        /// enclosed by the rectangle for which two opposite corners are specified.
        /// The arc starts at the passed starting angle and extends to the starting angle + extent
        /// </remarks>
        /// <param name="x1">corner-coordinate of the enclosing rectangle, first corner</param>
        /// <param name="y1">corner-coordinate of the enclosing rectangle, first corner</param>
        /// <param name="x2">corner-coordinate of the enclosing rectangle, second corner</param>
        /// <param name="y2">corner-coordinate of the enclosing rectangle, second corner</param>
        /// <param name="startAng">starting angle in degrees</param>
        /// <param name="extent">extent of the arc</param>
        /// <param name="cv">canvas to paint on</param>
        public static void Arc(double x1, double y1, double x2, double y2, double startAng, double extent, PdfCanvas
             cv) {
            Arc(x1, y1, x2, y2, startAng, extent, cv, null);
        }

        /// <summary>
        /// Draw an arc on the passed canvas with provided transform,
        /// enclosed by the rectangle for which two opposite corners are specified.
        /// </summary>
        /// <remarks>
        /// Draw an arc on the passed canvas with provided transform,
        /// enclosed by the rectangle for which two opposite corners are specified.
        /// The arc starts at the passed starting angle and extends to the starting angle + extent
        /// </remarks>
        /// <param name="x1">corner-coordinate of the enclosing rectangle, first corner</param>
        /// <param name="y1">corner-coordinate of the enclosing rectangle, first corner</param>
        /// <param name="x2">corner-coordinate of the enclosing rectangle, second corner</param>
        /// <param name="y2">corner-coordinate of the enclosing rectangle, second corner</param>
        /// <param name="startAng">starting angle in degrees</param>
        /// <param name="extent">extent of the arc</param>
        /// <param name="cv">canvas to paint on</param>
        /// <param name="transform">
        /// 
        /// <see cref="iText.Kernel.Geom.AffineTransform"/>
        /// to apply before drawing,
        /// or
        /// <see langword="null"/>
        /// in case transform shouldn't be applied
        /// </param>
        public static void Arc(double x1, double y1, double x2, double y2, double startAng, double extent, PdfCanvas
             cv, AffineTransform transform) {
            IList<double[]> ar = PdfCanvas.BezierArc(x1, y1, x2, y2, startAng, extent);
            if (!ar.IsEmpty()) {
                foreach (double[] pt in ar) {
                    if (transform != null) {
                        transform.Transform(pt, 0, pt, 0, pt.Length / 2);
                    }
                    cv.CurveTo(pt[2], pt[3], pt[4], pt[5], pt[6], pt[7]);
                }
            }
        }

        /// <summary>Perform stroke or fill operation for closed figure (e.g. Ellipse, Polygon, Circle).</summary>
        /// <param name="fillRuleRawValue">fill rule (e.g. evenodd, nonzero)</param>
        /// <param name="currentCanvas">canvas to draw on</param>
        /// <param name="doStroke">if true, stroke operation will be performed, fill otherwise</param>
        public static void DoStrokeOrFillForClosedFigure(String fillRuleRawValue, PdfCanvas currentCanvas, bool doStroke
            ) {
            if (SvgConstants.Values.FILL_RULE_EVEN_ODD.EqualsIgnoreCase(fillRuleRawValue)) {
                if (doStroke) {
                    currentCanvas.ClosePathEoFillStroke();
                }
                else {
                    currentCanvas.EoFill();
                }
            }
            else {
                if (doStroke) {
                    currentCanvas.ClosePathFillStroke();
                }
                else {
                    currentCanvas.Fill();
                }
            }
        }
    }
}
