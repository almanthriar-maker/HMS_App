namespace Healthcare_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TEMP STORAEGE 
            //to use as seed data
            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnosis = new string[100];
            bool[] admitted = new bool[100];       // true = currently admitted
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100];     // e.g. "Cardiology", "Orthopedics"
            int[] visitCount = new int[100];        // how many times admitted
            double[] billingAmount = new double[100];     // total fees owed
            int lastPatientIndex = -1;


            //patient1: 
            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Ali Hassan";
            patientIDs[lastPatientIndex] = "P001";
            diagnosis[lastPatientIndex] = "Flu";
            departments[lastPatientIndex] = "General";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 2;
            billingAmount[lastPatientIndex] = 0;


            //patient2:
            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Sara Ahmed";
            patientIDs[lastPatientIndex] = "P002";
            diagnosis[lastPatientIndex] = "Fracture";
            departments[lastPatientIndex] = "Orthopedics";
            admitted[lastPatientIndex] = true;
            assignedDoctors[lastPatientIndex] = "Dr. Noor";
            visitCount[lastPatientIndex] = 4;
            billingAmount[lastPatientIndex] = 0;



            //patient3:
            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Omar Khalid";
            patientIDs[lastPatientIndex] = "P003";
            diagnosis[lastPatientIndex] = "Diabetes";
            departments[lastPatientIndex] = "Cardiology";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 1;
            billingAmount[lastPatientIndex] = 0;



            bool exit = false;
            while (exit == false)





            {

                Console.WriteLine("Healthcare_Management_System");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. List All Admitted Patients");
                Console.WriteLine("6. Transfer Patient to Another Doctor");
                Console.WriteLine("7. View Most Visited Patients");
                Console.WriteLine("8. Search Patients by Department");
                Console.WriteLine("9. Billing Report");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Choose option: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        lastPatientIndex++;

                        Console.Write("patientNames: ");
                        patientNames[lastPatientIndex] = Console.ReadLine();

                        Console.Write("patientIDs: ");
                        patientIDs[lastPatientIndex] = Console.ReadLine();

                        Console.Write("diagnosis: ");
                        diagnosis[lastPatientIndex] = Console.ReadLine();


                        Console.Write("departments: ");
                        departments[lastPatientIndex] = Console.ReadLine();


                        admitted[lastPatientIndex] = false;
                        visitCount[lastPatientIndex] = 0;
                        billingAmount[lastPatientIndex] = 0;

                        Console.WriteLine("Patient registered successfully!");

                        break;


                    case 2:


                        Console.Write("patient ID or name:");
                        string input = Console.ReadLine();

                        int foundIndex = -1;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == input || patientNames[i] == input)
                            {
                                foundIndex = i;
                                break;
                            }
                        }

                        if (foundIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            return;
                        }

                        if (admitted[foundIndex])
                        {
                            Console.WriteLine("Patient is already admitted under " + assignedDoctors[foundIndex]);
                            return;
                        }

                        Console.Write("Enter Doctor Name: ");
                        string doctor = Console.ReadLine();

                        admitted[foundIndex] = true;
                        assignedDoctors[foundIndex] = doctor;
                        visitCount[foundIndex]++;

                        Console.WriteLine("Patient admitted successfully and assigned to " + doctor);
                        Console.WriteLine("This patient has been admitted " + visitCount[foundIndex] + " times");

                        break;


                    case 3:

                        Console.Write("patient ID or name:");
                        string Input = Console.ReadLine();

                        int FoundIndex = -1;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == Input || patientNames[i] == Input)
                            {
                                FoundIndex = i;
                                break;
                            }
                        }

                        if (FoundIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            return;
                        }

                        if (!admitted[FoundIndex])
                        {
                            Console.WriteLine("This patient is not currently admitted");
                            return;
                        }

                        double visitCharges = 0;
                        Console.Write("Was there a consultation fee? (yes/no): ");
                        string consult = Console.ReadLine().ToLower();

                        if (consult == "yes")
                        {
                            Console.Write("Enter consultation fee: ");
                            double.TryParse(Console.ReadLine(), out double fee);
                            visitCharges += fee;
                        }

                        Console.Write("Any medication charges? (yes/no): ");
                        string meds = Console.ReadLine().ToLower();

                        if (meds == "yes")
                        {
                            Console.Write("Enter medication charges: ");
                            double.TryParse(Console.ReadLine(), out double medFee);
                            visitCharges += medFee;
                        }
                        billingAmount[FoundIndex] += visitCharges;
                        admitted[FoundIndex] = false;
                        assignedDoctors[FoundIndex] = "";

                        if (visitCharges > 0)
                        {
                            Console.WriteLine("Total charges added this visit: " + visitCharges + " OMR");
                        }
                        else
                        {
                            Console.WriteLine("No charges recorded for this visit");
                        }

                        Console.WriteLine("Patient discharged successfully!");

                        break;

                    case 4:
                        Console.Write("Enter Patient ID or Name: ");
                        string Inpot = Console.ReadLine();

                        int FaoundIndex = -1;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == Inpot || patientNames[i] == Inpot)
                            {
                                FaoundIndex = i;
                                break;
                            }
                        }
                        if (FaoundIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            return;
                        }
                        Console.WriteLine("\n--- Patient Details ---");
                        Console.WriteLine("Name: " + patientNames[FaoundIndex]);
                        Console.WriteLine("ID: " + patientIDs[FaoundIndex]);
                        Console.WriteLine("Diagnosis: " + diagnosis[FaoundIndex]);
                        Console.WriteLine("Department: " + departments[FaoundIndex]);

                        Console.WriteLine("Admission Status: " +
                            (admitted[FaoundIndex] ? "Admitted" : "Not Admitted"));

                        Console.WriteLine("Visit Count: " + visitCount[FaoundIndex]);
                        Console.WriteLine("Total Billing Amount: " + billingAmount[FaoundIndex] + " OMR");

                        if (admitted[FaoundIndex])
                        {
                            Console.WriteLine("Assigned Doctor: " + assignedDoctors[FaoundIndex]);
                        }

                        break;



                    case 5:

                        bool foundAny = false;

                        Console.WriteLine("\n--- Admitted Patients ---");

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (admitted[i])
                            {
                                foundAny = true;

                                Console.WriteLine("Name: " + patientNames[i]);
                                Console.WriteLine("ID: " + patientIDs[i]);
                                Console.WriteLine("Diagnosis: " + diagnosis[i]);
                                Console.WriteLine("Department: " + departments[i]);
                                Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);
                                Console.WriteLine("");
                            }
                        }

                        if (!foundAny)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }

                        break;


                    case 6:

                        Console.Write("current doctor name:");
                        string currentDoctor = Console.ReadLine();

                        Console.Write("new doctor name:");
                        string newDoctor = Console.ReadLine();

                        int FaaoundIndex = -1;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (assignedDoctors[i] == currentDoctor && admitted[i])
                            {
                                FaaoundIndex = i;
                                break;
                            }
                        }

                        if (FaaoundIndex == -1)
                        {
                            Console.WriteLine("No admitted patient found under this doctor");
                            break;
                        }

                        assignedDoctors[FaaoundIndex] = newDoctor;

                        Console.WriteLine("Patient '" + patientNames[FaaoundIndex] + "' has been transferred to " + newDoctor);

                        break;


                    case 7:

                        Console.WriteLine("\n--- visitCount ---");
                        bool[] printed = new bool[lastPatientIndex + 1];

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            int maxIndex = -1;
                            for (int j = 0; j <= lastPatientIndex; j++)
                            {
                                if (!printed[i])
                                {
                                    if (maxIndex == -1 || visitCount[i] > visitCount[maxIndex])
                                    {
                                        maxIndex = i;
                                    }
                                }
                            }
                            if (maxIndex != -1)
                            {
                                printed[maxIndex] = true;
                                Console.WriteLine("Name: " + patientNames[i]);
                                Console.WriteLine("ID: " + patientIDs[i]);
                                Console.WriteLine("Diagnosis: " + diagnosis[i]);
                                Console.WriteLine("Department: " + departments[i]);
                                Console.WriteLine("Assigned Doctor: " + assignedDoctors[i]);
                                Console.WriteLine("");
                            }
                        }



                        break;

                    case 8:
                        Console.Write("Enter Department: ");
                        string inpuot = Console.ReadLine().ToLower();

                        bool fioundAny = false;
                        Console.WriteLine("\n--- Patients in Department ---");

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (departments[i].ToLower() == inpuot)
                            {
                                foundAny = true;

                                Console.WriteLine("ID: " + patientIDs[i]);
                                Console.WriteLine("Name: " + patientNames[i]);
                                Console.WriteLine("Diagnosis: " + diagnosis[i]);
                                Console.WriteLine("Status: " + (admitted[i] ? "Admitted" : "Not Admitted"));
                                Console.WriteLine("");
                            }
                        }

                        if (!fioundAny)
                        {
                            Console.WriteLine("No patients found in this department");
                        }

                        break;




                    case 9:


                        Console.WriteLine("\n--- Billing Report ---");
                        Console.WriteLine("1. System-wide total");
                        Console.WriteLine("2. Individual patient");
                        Console.Write("Choose option: ");

                        int subChoice = int.Parse(Console.ReadLine());

                        if (subChoice == 1)
                        {
                            double total = 0;

                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                total += billingAmount[i];
                            }

                            Console.WriteLine("Total Billing Amount (All Patients): " + total + " OMR");
                        }

                        else if (subChoice == 2)
                        {
                            Console.Write("Enter Patient ID or Name: ");
                            string iinput = Console.ReadLine();

                            int foioundIndex = -1;

                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                if (patientIDs[i] == iinput || patientNames[i] == iinput)
                                {
                                    foioundIndex = i;
                                    break;
                                }
                            }

                            if (foioundIndex == -1 || billingAmount[foioundIndex] == 0)
                            {
                                Console.WriteLine("No billing records found for this patient");
                            }
                            else
                            {
                                Console.WriteLine("Patient Name: " + patientNames[foioundIndex]);
                                Console.WriteLine("Total Billing Amount: " + billingAmount[foioundIndex] + " OMR");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Invalid option");
                        }

                        break;



                    case 10:
                        Console.WriteLine("Exiting system...");
                        Console.WriteLine("Thank you for using the Healthcare Management System!");
                        exit = true;

                        break;
                }

                Console.WriteLine("press any key");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}


