using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService {
    private testdbEntities ms_db;

    public Service() {

        ms_db = new testdbEntities();
        ms_db.Configuration.ProxyCreationEnabled = false;
    }

    // ------------ Service Contract -----------------
    public bool Login(string u, string p) {
        var auth_db = new authenticationEntities();
        return auth_db.accounts.Any(account => account.id.Equals(u) && account.pw.Equals(p));
    }

    public List<exam> GetAllExam() {
        return ms_db.exams.ToList();
    }

    public bool AddExam(exam exam) {
        ms_db.exams.Add(exam);
        return ms_db.SaveChanges() > 0;
    }

    public bool DeleteExam(exam exam) {
        ms_db.exams.Attach(exam);
        ms_db.exams.Remove(exam);
        return ms_db.SaveChanges() > 0;
    }

    public bool AddSubject(subject subject) {
        ms_db.subjects.Add(subject);
        return ms_db.SaveChanges() > 0;
    }

    public List<subject> GetSubject() {
        return ms_db.subjects.ToList();
    }
}
