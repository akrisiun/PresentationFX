#if !DONOTREFPRINTINGASMMETA
//---------------------------------------------------------------------------
//
// <copyright file=SerializerWriterCollator.cs company=Microsoft>
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
//
//
// Description: Plug-in document serializers implement this abstract class
//
//              See spec at <Need to post existing spec>
//
// History:
//  07/16/2005 : oliverfo - Created
//
//---------------------------------------------------------------------------
namespace System.Windows.Documents.Serialization
{
    using System;
    using System.Printing;
    using System.Windows.Media;
    using System.Security;

    /// <summary>
    /// SerializerWriterCollator is an abstract class that is implemented by plug-in document serializers
    /// Objects of this class are instantiated by SerializerWriter.CreateVisualCellator
    /// </summary>
    public abstract class SerializerWriterCollator
    {
        /// <summary>
        /// prepare for batch writing
        /// </summary>
        public abstract void BeginBatchWrite();
    
        /// <summary>
        /// Complete batch Writing
        /// </summary>
        public abstract void EndBatchWrite();
        
        /// <summary>
        /// Write a single Visual and close package
        /// </summary>
        public abstract void Write(Visual visual);

        /// <summary>
        /// Write a single Visual and close package
        /// </summary>
        /// <SecurityNote>
        ///   Critical : Takes critical argument of type PrintTicket from non-aptca assembly
        ///   Safe     : PrintTicket is strongly typed wrapper over an XML document that does not contain security critical information
        /// </SecurityNote>
        [SecuritySafeCritical]
        public abstract void Write(Visual visual, PrintTicket printTicket);

        /// <summary>
        /// Asynchronous Write a single Visual and close package
        /// </summary>
        public abstract void WriteAsync(Visual visual);

        /// <summary>
        /// Asynchronous Write a single Visual and close package
        /// </summary>
        public abstract void WriteAsync(Visual visual, object userState);

        /// <summary>
        /// Asynchronous Write a single Visual and close package
        /// </summary>
        /// <SecurityNote>
        ///   Critical : Takes critical argument of type PrintTicket from non-aptca assembly
        ///   Safe     : PrintTicket is strongly typed wrapper over an XML document that does not contain security critical information
        /// </SecurityNote>
        
        [SecuritySafeCritical]
        public abstract void WriteAsync(Visual visual, 
            PrintTicket  // Reach 
                printTicket);

        /// <summary>
        /// Asynchronous Write a single Visual and close package
        /// </summary>
        /// <SecurityNote>
        ///   Critical : Takes critical argument of type PrintTicket from non-aptca assembly
        ///   Safe     : PrintTicket is strongly typed wrapper over an XML document that does not contain security critical information
        /// </SecurityNote>
        [SecuritySafeCritical]
        public abstract void WriteAsync(Visual visual, 
            object // Reach : PrintTicket 
                printTicket, object userState);


        /// <summary>
        /// Cancel Asynchronous Write
        /// </summary>
        ///
        public abstract void CancelAsync();

        /// <summary>
        /// Cancel Write
        /// </summary>
        ///
        public abstract void Cancel();
    }
}
#endif
