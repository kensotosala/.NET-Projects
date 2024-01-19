Create database DBEmpleado;

use DbEmpleado;

Create table Departamento (
idDepartamento int primary key identity(1,1),
nombre varchar(50)
);

Create table Empleado (
idEmpleado int primary key identity(1,1),
nombreCompleto varchar(50),
idDepartamento int references Departamento(IdDepartamento),
sueldo int,
fechaContrato date
);

insert into Departamento(nombre) values
('Administración'),
('Marketing'),
('Ventas'),
('Comercio');

Insert into Empleado(nombreCompleto, idDepartamento, sueldo, fechaContrato) values
('Franco Hernandez', 1, 1400, getdate());

--=========================== Crear Procedimientos Almacenados ================================

-- GET Departments
create procedure sp_ListaDepartamentos
as
begin
	Select idDepartamento, nombre from Departamento
end

-- GET Empleados
create procedure sp_ListaEmpleados
as
begin
Set dateformat dmy
Select e.idEmpleado, e.nombreCompleto, e.idDepartamento, d.nombre, e.sueldo, CONVERT(char(10), e.fechaContrato, 103) as 'fechaContrato'
from Empleado as e
inner join Departamento as d on e.idDepartamento = d.idDepartamento
end;

-- POST Empleado
create procedure sp_GuardarEmpleado (@nombreCompleto varchar(50), @idDepartamento int, @sueldo int, @fechaContrato varchar(10))
as
begin
	set dateformat dmy
	Insert into Empleado(nombreCompleto, idDepartamento, sueldo, fechaContrato)
	values (@nombreCompleto, @idDepartamento, @sueldo, convert(date, @fechaContrato))
end;

-- PUT Empleado
create procedure sp_EditarEmpleado (@idEmpleado int, @nombreCompleto varchar(50), @idDepartamento int, @sueldo int, @fechaContrato varchar(10))
as
begin
	set dateformat dmy
	update Empleado set
	nombreCompleto = @nombreCompleto,
	idDepartamento = @idDepartamento,
	sueldo = @sueldo,
	@fechaContrato = convert(date, @fechaContrato)
	where idEmpleado = @idEmpleado
end;

-- DELETE Empleado
create procedure sp_EliminarEmpleado (@idEmpleado int)
as
begin
	delete from Empleado where idEmpleado = @idEmpleado
end;