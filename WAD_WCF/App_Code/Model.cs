﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class exam
{
    public int id { get; set; }
    public string subject_name { get; set; }
    public System.DateTime exam_time { get; set; }
    public string watcher { get; set; }

    public virtual subject subject { get; set; }
}

public partial class subject
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public subject()
    {
        this.exams = new HashSet<exam>();
    }

    public int id { get; set; }
    public string name { get; set; }
    public int duration { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual HashSet<exam> exams { get; set; }
}
