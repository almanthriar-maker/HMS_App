using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace HMS_APP
{
    internal class Program
    {
        // System Storage

        static string[] patientNames = new string[100];
        static string[] patientIDs = new string[100];
        static string[] diagnoses = new string[100];
        static bool[] admitted = new bool[100];
        static string[] assignedDoctors = new string[100];
        static string[] departments = new string[100];
        static int[] visitCount = new int[100];
        static double[] billingAmount = new double[100];


        static DateTime[] lastVisitDateStr = new DateTime[100];
        static DateTime[] lastDischargeDate = new DateTime[100];
        static int[] daysInHospital = new int[100];
        static string[] bloodType = new string[100];
        static string[] doctorNames = new string[50];
        static int[] doctorAvailableSlots = new int[50];
        static int[] doctorVisitCount = new int[50];
        static int lastDoctorIndex = -1;

        static int lastIndex = 0;
        static bool exit = false;



        static public void seedDate()

        {
            patientNames[lastIndex] = "Ali Hassan";
            patientIDs[lastIndex] = "P001";
            diagnoses[lastIndex] = "Flu";
            departments[lastIndex] = "General";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 2;
            billingAmount[lastIndex] = 0;
            lastVisitDateStr[lastIndex] = DateTime.Parse("2025-01-10");
            lastDischargeDate[lastIndex] = DateTime.Parse("2025-01-15");
            daysInHospital[lastIndex] = 12;
            bloodType[lastIndex] = "A+";

            lastDoctorIndex++;

            doctorNames[lastDoctorIndex] = "Dr.Noor";
            doctorAvailableSlots[lastDoctorIndex] = 5;
            doctorVisitCount[lastDoctorIndex] = 0;

            lastIndex++;

            patientNames[lastIndex] = "Sara Ahmed";
            patientIDs[lastIndex] = "P002";
            diagnoses[lastIndex] = "Fracture";
            departments[lastIndex] = "Orthopedics";
            admitted[lastIndex] = true;
            assignedDoctors[lastIndex] = "Dr. Noor";
            visitCount[lastIndex] = 4;
            billingAmount[lastIndex] = 0;
            lastVisitDateStr[lastIndex] = DateTime.Parse("2025-03-02");
            lastDischargeDate[lastIndex] = DateTime.Parse("");
            daysInHospital[lastIndex] = 8;
            bloodType[lastIndex] = "O-";

            lastDoctorIndex++;

            doctorNames[lastDoctorIndex] = "Dr.Salem";
            doctorAvailableSlots[lastDoctorIndex] = 3;
            doctorVisitCount[lastDoctorIndex] = 0;

            lastIndex++;

            patientNames[lastIndex] = "Omar Khalid";
            patientIDs[lastIndex] = "P003";
            diagnoses[lastIndex] = "Diabetes";
            departments[lastIndex] = "Cardiology";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            billingAmount[lastIndex] = 0;
            lastVisitDateStr[lastIndex] = DateTime.Parse("2024-12-20");
            lastDischargeDate[lastIndex] = DateTime.Parse("2024-12-28");
            daysInHospital[lastIndex] = 5;
            bloodType[lastIndex] = "B+";
            doctorNames[lastDoctorIndex] = "Dr.Hana";
            doctorAvailableSlots[lastDoctorIndex] = 8;
            doctorVisitCount[lastDoctorIndex] = 0;

        }

        static public void displayMenu()
        {
            Console.WriteLine("===== Healthcare Management System =====");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1.  Register New Patient");  //1 easy
            Console.WriteLine("2.  Admit Patient");//4 easy
            Console.WriteLine("3.  Discharge Patient");
            Console.WriteLine("4.  Search Patient"); //2 easy
            Console.WriteLine("5.  List All Admitted Patients"); //3 easy
            Console.WriteLine("6.  Transfer Patient to Another Doctor");
            Console.WriteLine("7.  View Most Visited Patients");
            Console.WriteLine("8.  Search Patients by Department");
            Console.WriteLine("9.  Billing Report");
            Console.WriteLine("10. Exit");
            Console.WriteLine("11. Add Doctor");
            Console.WriteLine("12. Doctor Salary Report");
            Console.Write("Choose option: ");


        }

        static public string registerPatient(string patientNames , string diagnoses , string departments , string bloodType)
        {
            patientIDs[lastIndex] = "P" + lastIndex.ToString("D3");

            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 0;
            billingAmount[lastIndex] = 0;

            lastVisitDateStr[lastIndex] = DateTime.Parse("");
            lastDischargeDate[lastIndex] = DateTime.Parse("");
            daysInHospital[lastIndex] = 0;
            return patientIDs[lastIndex];

        }

        static public void AdmitPatient()
        {
            Console.Write("Enter Patient ID or Name: ");
            string admitInput = Console.ReadLine().Trim();

            bool admitFound = false;

            for (int i = 0; i <= lastIndex; i++)
            {
                if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                {
                    admitFound = true;

                    if (!admitted[i])
                    {
                        // Step 1: Read and validate doctor name
                        Console.Write("Doctor Name: ");
                        string doctorName = Console.ReadLine().Trim();

                        bool doctorExists = false;
                        int doctorIndex = -1;

                        for (int j = 0; j <= lastDoctorIndex; j++)
                        {
                            if (doctorNames[j].ToLower() == doctorName.ToLower())
                            {
                                doctorExists = true;
                                doctorIndex = j;
                                break;
                            }
                        }

                        // Doctor not found
                        if (!doctorExists)
                        {
                            Console.WriteLine("Doctor not found in the system. Please register the doctor first.");
                            return;
                        }

                        // Check available slots
                        if (doctorAvailableSlots[doctorIndex] <= 0)
                        {
                            Console.WriteLine("Dr. " + doctorNames[doctorIndex] +
                                              " has no available slots at this time.");
                            return;
                        }

                        // Admit patient
                        assignedDoctors[i] = doctorNames[doctorIndex];
                        lastVisitDateStr[i] = DateTime.Now;
                        lastDischargeDate[i] = DateTime.MinValue;

                        admitted[i] = true;
                        visitCount[i]++;

                        // Update doctor registry
                        doctorAvailableSlots[doctorIndex]--;
                        doctorVisitCount[doctorIndex]++;

                        Console.WriteLine("Patient admitted successfully and assigned to " +
                                          assignedDoctors[i]);

                        Console.WriteLine("Dr. " + doctorNames[doctorIndex] +
                                          " now has " + doctorAvailableSlots[doctorIndex] +
                                          " slot(s) remaining.");

                        Console.WriteLine("Admission Date: " +
                                          lastVisitDateStr[i].ToString("yyyy-MM-dd HH:mm"));

                        if (visitCount[i] > 1)
                            Console.WriteLine("This patient has been admitted " +
                                              visitCount[i] + " times");
                        else
                            Console.WriteLine("This is the first time");
                    }
                    else
                    {
                        Console.WriteLine("Patient is already admitted under " +
                                          assignedDoctors[i]);
                    }

                    return;
                }
            }

            if (!admitFound)
            {
                Console.WriteLine("Patient not found");
            }
        }


        public static void DischargePatient()
        {
            Console.Write("Enter Patient ID or Name: ");
            string dischargeInput = Console.ReadLine().Trim();

            bool dischargeFound = false;

            for (int i = 0; i <= lastIndex; i++)
            {
                if (patientNames[i] == dischargeInput || patientIDs[i] == dischargeInput)
                {
                    dischargeFound = true;

                    if (admitted[i])
                    {
                        // Record discharge date
                        Console.Write("Enter Discharge Date (YYYY-MM-DD): ");
                        DateTime dischargeDate;
                        if (DateTime.TryParse(Console.ReadLine(), out dischargeDate))
                        {
                            lastDischargeDate[i] = dischargeDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                            return;
                        }

                        // Record days stayed
                        Console.Write("Enter number of days stayed in hospital: ");
                        int days;
                        if (int.TryParse(Console.ReadLine(), out days) && days > 0)
                        {
                            daysInHospital[i] += days;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number of days.");
                        }

                        double visitCharges = 0;

                        // Consultation fee
                        Console.Write("Was there a consultation fee? (yes/no): ");
                        string hasFee = Console.ReadLine().ToLower();

                        if (hasFee == "yes")
                        {
                            Console.Write("Enter consultation fee amount: ");
                            double fee;
                            if (double.TryParse(Console.ReadLine(), out fee) && fee > 0)
                            {
                                billingAmount[i] += fee;
                                visitCharges += fee;
                            }
                            else
                            {
                                Console.WriteLine("Invalid fee amount.");
                            }
                        }

                        // Medication charges
                        Console.Write("Any medication charges? (yes/no): ");
                        string hasMeds = Console.ReadLine().ToLower();

                        if (hasMeds == "yes")
                        {
                            Console.Write("Enter medication charges amount: ");
                            double med;
                            if (double.TryParse(Console.ReadLine(), out med) && med > 0)
                            {
                                billingAmount[i] += med;
                                visitCharges += med;
                            }
                            else
                            {
                                Console.WriteLine("Invalid medication amount.");
                            }
                        }

                        // Display charges
                        if (visitCharges > 0)
                            Console.WriteLine("Total charges added this visit: " +
                                              Math.Round(visitCharges, 2) + " OMR");
                        else
                            Console.WriteLine("No charges recorded for this visit");

                        Console.WriteLine("Total days in hospital: " + daysInHospital[i]);

                        // Restore doctor's slot
                        string assignedDoctor = assignedDoctors[i];
                        bool doctorLocated = false;
                        int doctorIndex = -1;

                        for (int j = 0; j <= lastDoctorIndex; j++)
                        {
                            if (!string.IsNullOrEmpty(doctorNames[j]) &&
                                doctorNames[j].ToLower() == assignedDoctor.ToLower())
                            {
                                doctorLocated = true;
                                doctorIndex = j;
                                break;
                            }
                        }

                        if (doctorLocated)
                        {
                            doctorAvailableSlots[doctorIndex]++;
                            Console.WriteLine("Dr. " + doctorNames[doctorIndex] +
                                              " now has " +
                                              doctorAvailableSlots[doctorIndex] +
                                              " slot(s) available.");
                        }
                        else
                        {
                            Console.WriteLine("Warning: assigned doctor not found in registry. Slots not updated.");
                        }

                        // Clear admission data
                        admitted[i] = false;
                        assignedDoctors[i] = "";

                        Console.WriteLine("Patient discharged successfully!");
                    }
                    else
                    {
                        Console.WriteLine("This patient is not currently admitted.");
                    }

                    return;
                }
            }

            if (!dischargeFound)
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public static void SearchPatient()
        {
            Console.Write("Enter Patient ID or Name: ");
            string searchInput = Console.ReadLine().Trim().ToUpper();

            bool patientFound = false;

            for (int i = 0; i <= lastIndex; i++)
            {
                if ((patientNames[i] != null && patientNames[i].ToUpper() == searchInput) ||
                    (patientIDs[i] != null && patientIDs[i].ToUpper() == searchInput))
                {
                    patientFound = true;

                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Name:            " + patientNames[i]);
                    Console.WriteLine("ID:              " + patientIDs[i].ToUpper());
                    Console.WriteLine("Diagnosis:       " + diagnoses[i] +
                                      " (" + diagnoses[i].Length + " characters)");
                    Console.WriteLine("Department:      " + departments[i]);
                    Console.WriteLine("Admitted:        " + admitted[i]);
                    Console.WriteLine("Total Visits:    " + visitCount[i]);
                    Console.WriteLine("Blood Type:      " + bloodType[i]);

                    // Last Visit Date
                    if (lastVisitDateStr[i] == DateTime.MinValue)
                        Console.WriteLine("Last Visit:      No admission recorded");
                    else
                        Console.WriteLine("Last Visit:      " +
                                          lastVisitDateStr[i].ToString("yyyy-MM-dd HH:mm"));

                    // Last Discharge Date
                    if (lastDischargeDate[i] == DateTime.MinValue)
                        Console.WriteLine("Last Discharge:  Still admitted");
                    else
                        Console.WriteLine("Last Discharge:  " +
                                          lastDischargeDate[i].ToString("yyyy-MM-dd"));

                    Console.WriteLine("Days in Hospital: " + daysInHospital[i]);

                    // Billing Information
                    Console.WriteLine("Total Billing:   " +
                        Convert.ToString(Math.Round(billingAmount[i], 2)) + " OMR");

                    // Doctor Information
                    if (!admitted[i])
                        Console.WriteLine("Patient not currently admitted.");
                    else
                        Console.WriteLine("Doctor:          " + assignedDoctors[i]);

                    Console.WriteLine("----------------------------------------");
                    return;
                }
            }

            if (!patientFound)
            {
                Console.WriteLine("Patient not found");
            }
        }

        public static void ListAdmittedPatients(string keyword)
{
    Console.WriteLine("\nCurrently Admitted Patients:");
    Console.WriteLine("----------------------------------------");

    bool hasAdmitted = false;
    double highestBilling = 0;

    for (int i = 0; i <= lastIndex; i++)
    {
        if (admitted[i])
        {
            // Apply keyword filter
            if (!string.IsNullOrEmpty(keyword) &&
                !patientNames[i].ToLower().Contains(keyword.ToLower()))
            {
                continue;
            }

            // Determine admission date
            string admittedDate;
            if (lastVisitDateStr[i] == DateTime.MinValue)
                admittedDate = "No date recorded";
            else
                admittedDate = lastVisitDateStr[i].ToString("yyyy-MM-dd HH:mm");

            // Display patient details
            Console.WriteLine(
                "Name: " + patientNames[i] +
                " | ID: " + patientIDs[i] +
                " | Diagnosis: " + diagnoses[i] +
                " | Department: " + departments[i] +
                " | Doctor: " + assignedDoctors[i] +
                " | Admitted Since: " + admittedDate
            );

            hasAdmitted = true;

            // Track highest billing
            highestBilling = Math.Max(highestBilling, billingAmount[i]);

            // Display visit count
            if (visitCount[i] > 1)
                Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
            else
                Console.WriteLine("This is the first time");

            Console.WriteLine("----------------------");
        }
    }

    // Summary output
    if (!hasAdmitted)
    {
        Console.WriteLine("No patients currently admitted");
    }
    else
    {
        Console.WriteLine("Highest billing among admitted patients: " +
                          Convert.ToString(Math.Round(highestBilling, 2)) + " OMR");
    }
}


        public static void TransferPatient()
        {
            Console.Write("Enter current doctor name: ");
            string currentDoctor = Console.ReadLine().Trim();
            currentDoctor = currentDoctor.Replace("Dr ", "Dr. ");

            Console.Write("Enter new doctor name: ");
            string newDoctor = Console.ReadLine().Trim();
            newDoctor = newDoctor.Replace("Dr ", "Dr. ");

            // Ensure doctor names are different
            if (currentDoctor.Equals(newDoctor, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Doctor names must be different. Transfer cancelled.");
                return;
            }

            // Validate new doctor exists in registry
            bool newDoctorExists = false;
            int newDoctorIndex = -1;

            for (int j = 0; j <= lastDoctorIndex; j++)
            {
                if (!string.IsNullOrEmpty(doctorNames[j]) &&
                    doctorNames[j].Equals(newDoctor, StringComparison.OrdinalIgnoreCase))
                {
                    newDoctorExists = true;
                    newDoctorIndex = j;
                    break;
                }
            }

            if (!newDoctorExists)
            {
                Console.WriteLine("New doctor not found in the system. Please register the doctor first.");
                return;
            }

            // Check slot availability
            if (doctorAvailableSlots[newDoctorIndex] <= 0)
            {
                Console.WriteLine("Dr. " + doctorNames[newDoctorIndex] +
                                  " has no available slots at this time.");
                return;
            }

            bool patientTransferred = false;

            for (int i = 0; i <= lastIndex; i++)
            {
                if (!string.IsNullOrEmpty(assignedDoctors[i]) &&
                    assignedDoctors[i].Equals(currentDoctor, StringComparison.OrdinalIgnoreCase) &&
                    admitted[i])
                {
                    // Find current doctor index
                    int currentDoctorIndex = -1;
                    for (int j = 0; j <= lastDoctorIndex; j++)
                    {
                        if (doctorNames[j].Equals(currentDoctor, StringComparison.OrdinalIgnoreCase))
                        {
                            currentDoctorIndex = j;
                            break;
                        }
                    }

                    // Update doctor slots
                    if (currentDoctorIndex != -1)
                        doctorAvailableSlots[currentDoctorIndex]++;

                    doctorAvailableSlots[newDoctorIndex]--;
                    doctorVisitCount[newDoctorIndex]++;

                    // Transfer patient
                    assignedDoctors[i] = doctorNames[newDoctorIndex];
                    patientTransferred = true;

                    Console.WriteLine("Patient '" + patientNames[i] +
                                      "' has been transferred to " +
                                      doctorNames[newDoctorIndex]);

                    // Display last admission date
                    if (lastVisitDateStr[i] == DateTime.MinValue)
                    {
                        Console.WriteLine("Patient last admitted on: No admission recorded");
                    }
                    else
                    {
                        Console.WriteLine("Patient last admitted on: " +
                                          lastVisitDateStr[i].ToString("yyyy-MM-dd HH:mm"));
                    }

                    return;
                }
            }

            if (!patientTransferred)
            {
                Console.WriteLine("No admitted patients found under this doctor.");
            }
        }


        public static void ViewMostVisitedPatients()
        {
            Console.WriteLine("Most Visited Patients (by visit count):");
            Console.WriteLine("----------------------------------------");

            // Check if there are any patients
            if (lastIndex < 0)
            {
                Console.WriteLine("No patients registered in the system.");
                return;
            }

            // Create a temporary array to preserve original visit counts
            int[] tempVisits = new int[lastIndex + 1];

            for (int i = 0; i <= lastIndex; i++)
            {
                tempVisits[i] = visitCount[i];
            }

            bool hasValidData = false;

            // Selection sort-style display (descending order)
            for (int pass = 0; pass <= lastIndex; pass++)
            {
                int maxIndex = -1;

                for (int i = 0; i <= lastIndex; i++)
                {
                    if (tempVisits[i] >= 0 &&
                        (maxIndex == -1 || tempVisits[i] > tempVisits[maxIndex]))
                    {
                        maxIndex = i;
                    }
                }

                // Stop if no more valid entries
                if (maxIndex == -1 || tempVisits[maxIndex] < 0)
                    break;

                hasValidData = true;

                Console.WriteLine(
                    "ID: " + patientIDs[maxIndex] +
                    " | Name: " + patientNames[maxIndex] +
                    " | Visits: " + tempVisits[maxIndex]);

                // Mark as processed
                tempVisits[maxIndex] = -1;
            }

            if (!hasValidData)
            {
                Console.WriteLine("No visit records available.");
            }
        }


        public static void SearchPatientsByDepartment()
        {
            Console.Write("Enter department name: ");
            string searchDept = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(searchDept))
            {
                Console.WriteLine("Department name cannot be empty.");
                return;
            }

            bool deptFound = false;

            Console.WriteLine("\nPatients in department '" + searchDept.ToUpper() + "':");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i <= lastIndex; i++)
            {
                if (!string.IsNullOrEmpty(departments[i]) &&
                    departments[i].ToLower().Contains(searchDept.ToLower()))
                {
                    deptFound = true;

                    // Determine patient status
                    string status = admitted[i] ? "Admitted" : "Not Admitted";

                    // Shorten long diagnoses
                    string diagnosisDisplay;
                    if (!string.IsNullOrEmpty(diagnoses[i]) && diagnoses[i].Length > 15)
                    {
                        diagnosisDisplay = diagnoses[i].Substring(0, 15) + "...";
                    }
                    else
                    {
                        diagnosisDisplay = diagnoses[i];
                    }

                    // Display patient details
                    Console.WriteLine(
                        "ID: " + patientIDs[i] +
                        " | Name: " + patientNames[i] +
                        " | Diagnosis: " + diagnosisDisplay +
                        " | Status: " + status +
                        " | Blood Type: " + bloodType[i]
                    );
                }
            }

            if (!deptFound)
            {
                Console.WriteLine("No patients found in this department.");
            }
        }


        public static void BillingReport()
     
        {
            Console.WriteLine("Billing Report:");
            Console.WriteLine("1. System-wide total");
            Console.WriteLine("2. Individual patient");
            Console.Write("Choose option: ");

            if (!int.TryParse(Console.ReadLine(), out int billingOption))
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                return;
            }

            switch (billingOption)
            {
                case 1:
                    if (lastIndex == 0)
                    {
                        Console.WriteLine("No patients in the system.");
                        return;
                    }

                    double total = 0;

                    for (int i = 0; i < lastIndex; i++)
                    {
                        total += billingAmount[i];
                    }

                    Console.WriteLine("System-wide total = " + total);
                    break;

                case 2:
                    Console.Write("Enter patient name: ");
                    string name = Console.ReadLine();

                    bool found = false;

                    for (int i = 0; i < lastIndex; i++)
                    {
                        if (patientNames[i].Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Patient: " + patientNames[i]);
                            Console.WriteLine("Bill: " + billingAmount[i]);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Patient not found.");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter 1 or 2.");
                    break;
            }
        }

        public static bool ExitSystem()
        {
            Console.WriteLine("Exiting system...");
            Console.WriteLine("----------------------------------------");

            Console.Write("Are you sure you want to exit? (yes/no): ");
            string wantExit = Console.ReadLine();

            if (wantExit != null && wantExit.Trim().ToLower() == "no")
            {
                return false; // do NOT exit
            }

            Console.WriteLine("Thank you for using the Healthcare Management System!");
            return true; // exit system
        }


        public static void RegisterDoctor()
        {
            Console.Write("Enter Doctor Full Name: ");
            string doctorInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(doctorInput))
            {
                Console.WriteLine("Invalid name. Doctor not registered.");
                return;
            }

            doctorInput = doctorInput.Substring(0, 1).ToUpper() +
                          doctorInput.Substring(1);

            // Check duplicate
            bool duplicateExists = false;

            for (int i = 0; i <= lastDoctorIndex; i++)
            {
                if (doctorNames[i].Equals(doctorInput, StringComparison.OrdinalIgnoreCase))
                {
                    duplicateExists = true;
                    break;
                }
            }

            if (duplicateExists)
            {
                Console.WriteLine("Doctor already exists in the system.");
                return;
            }

            // Slots input
            Console.Write("Enter Number of Available Slots: ");
            if (!int.TryParse(Console.ReadLine(), out int slots) || slots < 1)
            {
                Console.WriteLine("Invalid slot count. Doctor not registered.");
                return;
            }

            // Store doctor
            lastDoctorIndex++;
            doctorNames[lastDoctorIndex] = doctorInput;
            doctorAvailableSlots[lastDoctorIndex] = slots;
            doctorVisitCount[lastDoctorIndex] = 0;

            Console.WriteLine($"Doctor {doctorInput} registered successfully with {slots} available slots.");
        }



        public static void DoctorSalaryReport()
        {
            Console.WriteLine("Doctor Salary Report");
            Console.WriteLine("----------------------------------------");

            if (lastDoctorIndex == -1)
            {
                Console.WriteLine("No doctors registered in the system.");
                return;
            }

            double highestSalary = 0;
            int highestIndex = -1;

            for (int i = 0; i <= lastDoctorIndex; i++)
            {
                double salary = 300 + (doctorVisitCount[i] * 15);
                salary = Math.Round(salary, 2);

                if (salary > highestSalary)
                {
                    highestSalary = salary;
                    highestIndex = i;
                }

                Console.WriteLine(
                    doctorNames[i] +
                    " | Visits: " + doctorVisitCount[i] +
                    " | Available Slots: " + doctorAvailableSlots[i] +
                    " | Salary: " + salary + " OMR"
                );
            }

            Console.WriteLine("----------------------------------------");

            if (highestIndex != -1)
            {
                Console.WriteLine(
                    "Highest earning doctor: " +
                    doctorNames[highestIndex] +
                    " — " +
                    highestSalary + " OMR"
                );
            }
        }


        static void Main(string[] args) //startig point
        {


            seedDate();
            
            while (exit == false)
            {
                displayMenu();

                Console.Write("Choose option: ");

                int choice = 0;

                try
                {

                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please choose a number from 1 to 10.");
                }

                switch (choice)
                {




                    case 1: // Register New Patient

                        Console.Write("Patient Name: ");
                        patientNames[lastIndex] = Console.ReadLine().Trim();

                     
                        Console.Write("Diagnosis: ");
                        diagnoses[lastIndex] = Console.ReadLine().Trim();

                        Console.Write("Department: ");
                        departments[lastIndex] = Console.ReadLine().Trim();


                        Console.Write("Enter Blood Type: ");
                        bloodType[lastIndex] = Console.ReadLine().ToUpper();

                        string PID = registerPatient (patientNames[lastIndex], diagnoses[lastIndex], departments[lastIndex], bloodType[lastIndex]);




                        Console.WriteLine("Patient registered successfully with ID :" + PID);

                        lastIndex++;


                        break;

                    case 2:  //AdmitPatient

                        AdmitPatient();
                        break;


                    case 3:  // DischargePatient
                        DischargePatient();
                        break;



                    case 4:  // SearchPatient
                        SearchPatient();


                        break;


                    case 5: // ListAdmittedPatients
                        Console.WriteLine("Filter by name keyword (press Enter to skip): ");
                        string keyword = Console.ReadLine().Trim().ToLower();

                        ListAdmittedPatients(keyword);
                        break;



                    case 6: // Transfer Patient to Another Doctor
                        TransferPatient();
                       
                        break;


                    case 7: // View Most Visited Patients
                        ViewMostVisitedPatients();

                        break;


                    case 8: // Search Patients by Department

                        SearchPatientsByDepartment();
                        break;

                    case 9: // Billing Report

                        BillingReport();
                        break;


                    case 10: // Exit
                        exit = ExitSystem();

                        break;



                    case 11: //RegisterDoctor
                        RegisterDoctor();

                        break;


                    case 12:  // DoctorSalaryReport

                        DoctorSalaryReport();
                        break;


                       
                }
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}


