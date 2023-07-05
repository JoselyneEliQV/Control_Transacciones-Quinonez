using Taller_Metodos_CRUD_Quinonez.Models;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        AgregarCitaMedica();
    }

    public static void AgregarPaciente()
    {
        Console.WriteLine("++++ Agregar Paciente ++++");

        Paciente paciente = new Paciente();

        Console.Write("Nombre: ");
        paciente.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        paciente.Apellido = Console.ReadLine();

        Console.Write("Direcci�n: ");
        paciente.Direccion = Console.ReadLine();

        Console.Write("Tel�fono: ");
        paciente.Telefono = Console.ReadLine();

        Console.Write("Fecha de Nacimiento (yyyy-mm-dd): ");
        paciente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            context.Pacientes.Add(paciente);
            context.SaveChanges();

            Console.WriteLine("El paciente ha sido agregado.");
        }
    }

    public static void ConsultarPaciente()
    {
        Console.WriteLine("++++ Consultar Paciente ++++");
        Console.Write("Ingrese el Id del paciente: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Paciente paciente = context.Pacientes.Find(id);

            if (paciente != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Direcci�n", "Tel�fono", "Fecha de Nacimiento");
                table.AddRow(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.Direccion, paciente.Telefono, paciente.FechaNacimiento.ToShortDateString());
                Console.WriteLine();
                table.Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }

    public static void ModificarPaciente()
    {
        Console.WriteLine("++++ Modificar Paciente ++++");
        Console.Write("Ingrese el Id del paciente a modificar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Paciente paciente = context.Pacientes.Find(id);

            if (paciente != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Direcci�n", "Tel�fono", "Fecha de Nacimiento");
                table.AddRow(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.Direccion, paciente.Telefono, paciente.FechaNacimiento.ToShortDateString());
                Console.WriteLine();
                table.Write(Format.Alternative);

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                paciente.Nombre = string.IsNullOrEmpty(nuevoNombre) ? paciente.Nombre : nuevoNombre;

                Console.Write("Nuevo apellido: ");
                string nuevoApellido = Console.ReadLine();
                paciente.Apellido = string.IsNullOrEmpty(nuevoApellido) ? paciente.Apellido : nuevoApellido;

                Console.Write("Nueva direcci�n: ");
                string nuevaDireccion = Console.ReadLine();
                paciente.Direccion = string.IsNullOrEmpty(nuevaDireccion) ? paciente.Direccion : nuevaDireccion;

                Console.Write("Nuevo tel�fono: ");
                string nuevoTelefono = Console.ReadLine();
                paciente.Telefono = string.IsNullOrEmpty(nuevoTelefono) ? paciente.Telefono : nuevoTelefono;

                Console.Write("Nueva fecha de nacimiento (yyyy-mm-dd): ");
                string nuevaFechaNacimientoStr = Console.ReadLine();
                DateTime nuevaFechaNacimiento;
                if (DateTime.TryParse(nuevaFechaNacimientoStr, out nuevaFechaNacimiento))
                {
                    paciente.FechaNacimiento = nuevaFechaNacimiento;
                }

                context.SaveChanges();

                Console.WriteLine("Paciente modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }

    public static void EliminarPaciente()
    {
        Console.WriteLine("++++ Eliminar Paciente ++++");
        Console.Write("Ingrese el Id del paciente a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Paciente paciente = context.Pacientes.Find(id);

            if (paciente != null)
            {
                context.Pacientes.Remove(paciente);
                context.SaveChanges();

                Console.WriteLine("Paciente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }


    // Agregar doctor
    // Agregar doctor
    public static void AgregarDoctor()
    {
        Console.WriteLine("++++ Agregar Doctor ++++");

        Doctor doctor = new Doctor();

        Console.Write("Nombre: ");
        doctor.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        doctor.Apellido = Console.ReadLine();

        Console.Write("Especialidad: ");
        doctor.Especialidad = Console.ReadLine();

        Console.Write("Direcci�n de consultorio: ");
        doctor.DireccionConsultorio = Console.ReadLine();

        Console.Write("Tel�fono de consultorio: ");
        doctor.TelefonoConsultorio = Console.ReadLine();

        Console.Write("Correo electr�nico: ");
        doctor.CorreoElectronico = Console.ReadLine();

        using (var context = new AplicationDbContext())
        {
            context.Doctores.Add(doctor);
            context.SaveChanges();

            Console.WriteLine("El doctor ha sido agregado.");
        }
    }

    // Consultar doctor
    public static void ConsultarDoctor()
    {
        Console.WriteLine("++++ Consultar Doctor ++++");
        Console.Write("Ingrese el Id del doctor: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Doctor doctor = context.Doctores.Find(id);

            if (doctor != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Especialidad", "Direcci�n de Consultorio", "Tel�fono de Consultorio", "Correo Electr�nico");
                table.AddRow(doctor.Id, doctor.Nombre, doctor.Apellido, doctor.Especialidad, doctor.DireccionConsultorio, doctor.TelefonoConsultorio, doctor.CorreoElectronico);
                Console.WriteLine();
                table.Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine("Doctor no encontrado.");
            }
        }
    }

    // Modificar doctor
    public static void ModificarDoctor()
    {
        Console.WriteLine("++++ Modificar Doctor ++++");
        Console.Write("Ingrese el Id del doctor a modificar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Doctor doctor = context.Doctores.Find(id);

            if (doctor != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Especialidad", "Direcci�n de Consultorio", "Tel�fono de Consultorio", "Correo Electr�nico");
                table.AddRow(doctor.Id, doctor.Nombre, doctor.Apellido, doctor.Especialidad, doctor.DireccionConsultorio, doctor.TelefonoConsultorio, doctor.CorreoElectronico);
                Console.WriteLine();
                table.Write(Format.Alternative);

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                doctor.Nombre = string.IsNullOrEmpty(nuevoNombre) ? doctor.Nombre : nuevoNombre;

                Console.Write("Nuevo apellido: ");
                string nuevoApellido = Console.ReadLine();
                doctor.Apellido = string.IsNullOrEmpty(nuevoApellido) ? doctor.Apellido : nuevoApellido;

                Console.Write("Nueva especialidad: ");
                string nuevaEspecialidad = Console.ReadLine();
                doctor.Especialidad = string.IsNullOrEmpty(nuevaEspecialidad) ? doctor.Especialidad : nuevaEspecialidad;

                Console.Write("Nueva direcci�n de consultorio: ");
                string nuevaDireccionConsultorio = Console.ReadLine();
                doctor.DireccionConsultorio = string.IsNullOrEmpty(nuevaDireccionConsultorio) ? doctor.DireccionConsultorio : nuevaDireccionConsultorio;

                Console.Write("Nuevo tel�fono de consultorio: ");
                string nuevoTelefonoConsultorio = Console.ReadLine();
                doctor.TelefonoConsultorio = string.IsNullOrEmpty(nuevoTelefonoConsultorio) ? doctor.TelefonoConsultorio : nuevoTelefonoConsultorio;

                Console.Write("Nuevo correo electr�nico: ");
                string nuevoCorreoElectronico = Console.ReadLine();
                doctor.CorreoElectronico = string.IsNullOrEmpty(nuevoCorreoElectronico) ? doctor.CorreoElectronico : nuevoCorreoElectronico;

                context.SaveChanges();

                Console.WriteLine("Doctor modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Doctor no encontrado.");
            }
        }
    }

    // Eliminar doctor
    public static void EliminarDoctor()
    {
        Console.WriteLine("++++ Eliminar Doctor ++++");
        Console.Write("Ingrese el Id del doctor a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Doctor doctor = context.Doctores.Find(id);

            if (doctor != null)
            {
                context.Doctores.Remove(doctor);
                context.SaveChanges();

                Console.WriteLine("Doctor eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Doctor no encontrado.");
            }
        }
    }


    // Agregar cita m�dica
    public static void AgregarCitaMedica()
    {
        Console.WriteLine("++++ Agregar Cita M�dica ++++");

        CitaMedica citaMedica = new CitaMedica();

        Console.Write("Fecha (yyyy-mm-dd): ");
        citaMedica.Fecha = DateTime.Parse(Console.ReadLine());

        Console.Write("Descripci�n: ");
        citaMedica.Descripcion = Console.ReadLine();

        Console.Write("Id del paciente: ");
        int idPaciente = int.Parse(Console.ReadLine());

        Console.Write("Id del doctor: ");
        int idDoctor = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Paciente paciente = context.Pacientes.Find(idPaciente);

                    if (paciente == null)
                    {
                        Console.WriteLine("Paciente no encontrado.");
                        transaction.Rollback();
                        return;
                    }

                    citaMedica.Paciente = paciente;

                    Doctor doctor = context.Doctores.Find(idDoctor);

                    if (doctor == null)
                    {
                        Console.WriteLine("Doctor no encontrado.");
                        transaction.Rollback();
                        return;
                    }

                    citaMedica.Doctor = doctor;

                    context.CitasMedicas.Add(citaMedica);
                    context.SaveChanges();

                    transaction.Commit();

                    Console.WriteLine("La cita m�dica ha sido agregada.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar la cita m�dica: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }

    // Consultar cita m�dica
    public static void ConsultarCitaMedica()
    {
        Console.WriteLine("++++ Consultar Cita M�dica ++++");
        Console.Write("Ingrese el Id de la cita m�dica: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            CitaMedica citaMedica = context.CitasMedicas.Include(c => c.Paciente).Include(c => c.Doctor).FirstOrDefault(c => c.Id == id);

            if (citaMedica != null)
            {
                var table = new ConsoleTable("Id", "Fecha", "Descripci�n", "Id del Paciente", "Id del Doctor");
                table.AddRow(citaMedica.Id, citaMedica.Fecha.ToShortDateString(), citaMedica.Descripcion, citaMedica.Paciente.Id, citaMedica.Doctor.Id);
                Console.WriteLine();
                table.Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine("Cita m�dica no encontrada.");
            }
        }
    }

    // Modificar cita m�dica
    public static void ModificarCitaMedica()
    {
        Console.WriteLine("++++ Modificar Cita M�dica ++++");
        Console.Write("Ingrese el Id de la cita m�dica a modificar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            CitaMedica citaMedica = context.CitasMedicas.Include(c => c.Paciente).Include(c => c.Doctor).FirstOrDefault(c => c.Id == id);

            if (citaMedica != null)
            {
                var table = new ConsoleTable("Id", "Fecha", "Descripci�n", "Id del Paciente", "Id del Doctor");
                table.AddRow(citaMedica.Id, citaMedica.Fecha.ToShortDateString(), citaMedica.Descripcion, citaMedica.Paciente.Id, citaMedica.Doctor.Id);
                Console.WriteLine();
                table.Write(Format.Alternative);

                Console.Write("Nueva fecha (yyyy-mm-dd): ");
                string nuevaFechaStr = Console.ReadLine();
                DateTime nuevaFecha;
                if (DateTime.TryParse(nuevaFechaStr, out nuevaFecha))
                {
                    citaMedica.Fecha = nuevaFecha;
                }

                Console.Write("Nueva descripci�n: ");
                string nuevaDescripcion = Console.ReadLine();
                citaMedica.Descripcion = string.IsNullOrEmpty(nuevaDescripcion) ? citaMedica.Descripcion : nuevaDescripcion;

                Console.Write("Nuevo Id del paciente: ");
                int nuevoIdPaciente = int.Parse(Console.ReadLine());
                Paciente nuevoPaciente = context.Pacientes.Find(nuevoIdPaciente);
                if (nuevoPaciente != null)
                {
                    citaMedica.Paciente = nuevoPaciente;
                }
                else
                {
                    Console.WriteLine("Paciente no encontrado. El paciente actual se mantendr�.");
                }

                Console.Write("Nuevo Id del doctor: ");
                int nuevoIdDoctor = int.Parse(Console.ReadLine());
                Doctor nuevoDoctor = context.Doctores.Find(nuevoIdDoctor);
                if (nuevoDoctor != null)
                {
                    citaMedica.Doctor = nuevoDoctor;
                }
                else
                {
                    Console.WriteLine("Doctor no encontrado. El doctor actual se mantendr�.");
                }

                context.SaveChanges();

                Console.WriteLine("Cita m�dica modificada correctamente.");
            }
            else
            {
                Console.WriteLine("Cita m�dica no encontrada.");
            }
        }
    }

    // Eliminar cita m�dica
    public static void EliminarCitaMedica()
    {
        Console.WriteLine("++++ Eliminar Cita M�dica ++++");
        Console.Write("Ingrese el Id de la cita m�dica a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            CitaMedica citaMedica = context.CitasMedicas.Find(id);

            if (citaMedica != null)
            {
                context.CitasMedicas.Remove(citaMedica);
                context.SaveChanges();

                Console.WriteLine("Cita m�dica eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Cita m�dica no encontrada.");
            }
        }
    }
}