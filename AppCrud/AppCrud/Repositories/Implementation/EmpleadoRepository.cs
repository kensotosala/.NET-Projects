using System.Data.SqlClient;
using System.Reflection;
using CRUD_ASP.NET_MVC_ADO.NET.Models;
using CRUD_ASP.NET_MVC_ADO.NET.Repositories.Contract;

namespace CRUD_ASP.NET_MVC_ADO.NET.Repositories.Implementation
{
    public class EmpleadoRepository : IGenericRepository<Empleado>
    {
        private readonly string _cadenaSQL = "";
        public EmpleadoRepository(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("cadenaSQL");
        }
        public async Task<bool> Delete(int id)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new("sp_EliminarEmpleado", conexion);
                cmd.Parameters.AddWithValue("idEmpleado", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if (filas_afectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> Editar(Empleado modelo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new("sp_GuardarEmpleado", conexion);
                cmd.Parameters.AddWithValue("idEmpleado", modelo.idEmpleado);
                cmd.Parameters.AddWithValue("nombreCompleto", modelo.nombreCompleto);
                cmd.Parameters.AddWithValue("idDepartamento", modelo.refDepartamento.idDepartamento);
                cmd.Parameters.AddWithValue("sueldo", modelo.sueldo);
                cmd.Parameters.AddWithValue("fechaContrato", modelo.fechaContrato);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if (filas_afectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> Guardar(Empleado modelo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new("sp_GuardarEmpleado", conexion);
                cmd.Parameters.AddWithValue("nombreCompleto", modelo.nombreCompleto);
                cmd.Parameters.AddWithValue("idDepartamento", modelo.refDepartamento.idDepartamento);
                cmd.Parameters.AddWithValue("sueldo", modelo.sueldo);
                cmd.Parameters.AddWithValue("fechaContrato", modelo.fechaContrato);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();

                if(filas_afectadas > 0) {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public async Task<List<Empleado>> Lista()
        {
            List<Empleado> _lista = new List<Empleado>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaEmpleados", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _lista.Add(new Empleado
                        {
                            idEmpleado = Convert.ToInt32(dr["idDepartamento"]),
                            nombreCompleto = dr["nombreCompleto"].ToString(),
                            refDepartamento = new Departamento()
                            {
                                idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                nombre = dr["nombre"].ToString()
                            },
                            sueldo = Convert.ToInt32(dr["sueldo"]),
                            fechaContrato = dr["fechaContrato"].ToString()
                        });
                    }
                }
            }

            return _lista;
        }
    }
}
