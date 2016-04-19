using System.Collections.Generic;
using System.ServiceModel;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract, XmlSerializerFormat]
public interface IService
{
    // Authentication
    [OperationContract]
    bool Login(string u, string p);

    // TODO: Add your service operations here

    // User MS default entity
    [OperationContract]
    List<exam> GetAllExam();

    [OperationContract]
    bool AddExam(exam exam);

    [OperationContract]
    bool DeleteExam(exam exam);

    [OperationContract]
    bool AddSubject(subject subject);

    [OperationContract]
    List<subject> GetSubject();
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.