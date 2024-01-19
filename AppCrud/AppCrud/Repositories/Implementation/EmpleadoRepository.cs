using System.Data.SqlClient;
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
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Empleado modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(Empleado modelo)
        {
            throw new NotImplementedException();
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
