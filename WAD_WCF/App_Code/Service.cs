using System.Collections.Generic;
using System.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private readonly testdbEntities _msDb;

    public Service()
    {
        _msDb = new testdbEntities();
        _msDb.Configuration.ProxyCreationEnabled = false;
    }

    // ------------ Service Contract -----------------
    public bool Login(string u, string p)
    {
        var authDb = new authenticationEntities();
        return authDb.accounts.Any(account => account.id.Equals(u) && account.pw.Equals(p));
    }

    public List<exam> GetAllExam()
    {
        return _msDb.exams.ToList();
    }

    public bool AddExam(exam exam)
    {
        _msDb.exams.Add(exam);
        return _msDb.SaveChanges() > 0;
    }

    public bool DeleteExam(exam exam)
    {
        _msDb.exams.Attach(exam);
        _msDb.exams.Remove(exam);
        return _msDb.SaveChanges() > 0;
    }

    public bool AddSubject(subject subject)
    {
        _msDb.subjects.Add(subject);
        return _msDb.SaveChanges() > 0;
    }

    public List<subject> GetSubject()
    {
        return _msDb.subjects.ToList();
    }
}