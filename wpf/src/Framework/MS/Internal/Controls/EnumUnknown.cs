//------------------------------------------------------------------------------
// <copyright file="EnumKnown.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//
//
// Description: Helper object implementing IEnumUnknown for enumerating controls            
//
//              Source copied from AxContainer.cs
//
// History
//  04/17/05    KusumaV      Created
// 
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security;

using MS.Win32;
using NativeMethods = MS.Win32.NativeMethods;

namespace MS.Internal.Controls
{
    #region class EnumUnknown

    internal class EnumUnknownX : UnsafeNativeMethodsX.IEnumUnknown
    {
        private Object[] arr;
        private int loc;
        private int size;

        internal EnumUnknownX(Object[] arr)
        {
            this.arr = arr;
            this.loc = 0;
            this.size = (arr == null) ? 0 : arr.Length;
        }

        private EnumUnknownX(Object[] arr, int loc)
            : this(arr)
        {
            this.loc = loc;
        }


        //[PreserveSig]
        //int Next([In, MarshalAs(UnmanagedType.U4)]
        //        int celt,
        //    [Out]
        //        IntPtr rgelt,
        //    IntPtr pceltFetched);

        //[PreserveSig]
        //int Skip([In, MarshalAs(UnmanagedType.U4)]
        //        int celt);

        ///<SecurityNote>
        ///     Critical: Takes arbitrary pointers, writes to memory
        ///</SecurityNote> 
        [SecurityCritical]
        unsafe int UnsafeNativeMethodsX.IEnumUnknown.Next(int celt, IntPtr rgelt, IntPtr pceltFetched)
        {
            if (pceltFetched != IntPtr.Zero)
                Marshal.WriteInt32(pceltFetched, 0, 0);

            if (celt < 0)
            {
                return NativeMethods.E_INVALIDARG;
            }

            int fetched = 0;
            if (this.loc >= this.size)
            {
                fetched = 0;
            }
            else
            {
                for (; this.loc < this.size && fetched < celt; ++(this.loc))
                {
                    if (this.arr[this.loc] != null)
                    {
                        Marshal.WriteIntPtr(rgelt, Marshal.GetIUnknownForObject(this.arr[this.loc]));
                        rgelt = (IntPtr)((long)rgelt + (long)sizeof(IntPtr));
                        ++fetched;
                    }
                }
            }

            if (pceltFetched != IntPtr.Zero)
                Marshal.WriteInt32(pceltFetched, 0, fetched);

            if (fetched != celt)
            {
                return (NativeMethods.S_FALSE);
            }
            return NativeMethods.S_OK;
        }

        ///<SecurityNote>
        ///     Critical: Implements critical interface method
        ///</SecurityNote> 
        [SecurityCritical]
        int UnsafeNativeMethodsX.IEnumUnknown.Skip(int celt)
        {
            this.loc += celt;
            if (this.loc >= this.size)
            {
                return (NativeMethods.S_FALSE);
            }
            return NativeMethods.S_OK;
        }

        ///<SecurityNote>
        ///     Critical: Implements critical interface method
        ///</SecurityNote> 
        [SecurityCritical]
        void UnsafeNativeMethodsX.IEnumUnknown.Reset()
        {
            this.loc = 0;
        }

        ///<SecurityNote>
        ///     Critical: Implements critical interface method
        ///</SecurityNote> 
        [SecurityCritical]
        void UnsafeNativeMethodsX.IEnumUnknown.Clone(out UnsafeNativeMethodsX.IEnumUnknown ppenum)
        {
            ppenum = new EnumUnknownX(this.arr, this.loc);
        }
    }
    #endregion class EnumUnknown
}
