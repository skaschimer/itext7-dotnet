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

namespace iText.Signatures.Logs {
    /// <summary>Class which contains constants to be used in logging inside sign module.</summary>
    public sealed class SignLogMessageConstant {
        public const String EXCEPTION_WITHOUT_MESSAGE = "Unexpected exception without message was thrown during keystore processing";

        public const String UNABLE_TO_PARSE_AIA_CERT = "Unable to parse certificates coming from authority info " 
            + "access extension. Those won't be included into the certificate chain.";

        public const String REVOCATION_DATA_NOT_ADDED_VALIDITY_ASSURED = "Revocation data for certificate: \"{0}\" is not added due to validity assured - short term extension.";

        public const String UNABLE_TO_PARSE_REV_INFO = "Unable to parse signed data revocation info item " + "since it is incorrect or unsupported (e.g. SCVP Request and Response).";

        public const String VALID_CERTIFICATE_IS_REVOKED = "The certificate was valid on the verification date, " 
            + "but has been revoked since {0}.";

        private SignLogMessageConstant() {
        }
        // Private constructor will prevent the instantiation of this class directly
    }
}
