# TP-Integrador-CAI // Lautaro Gerlero, Lautaro Iriazabal
Sistema de Administración EletroHogar SA
Este repositorio contiene el código fuente del sistema de administración desarrollado para EletroHogar SA, una empresa dedicada a la compra-venta de artículos para el hogar.

Descripción General
El sistema fue desarrollado para abordar los desafíos existentes en la gestión del stock, historiales de clientes, proveedores, productos y transacciones comerciales de EletroHogar SA. Anteriormente, la empresa dependía de un proceso manual y un software no integrado, lo que generaba problemas en la actualización y seguimiento del stock, así como inconsistencias en la información.

Características y Funcionalidades Implementadas
Usuarios
  Registrar Usuarios: Permite el alta de usuarios según los lineamientos especificados. Aplica validaciones para el nombre de usuario y la contraseña. Los perfiles de Administradores ya están predefinidos.
  Baja de Usuarios: Permite dar de baja a usuarios, cambiando su estado a "INACTIVO".
  Login de Usuario: Implementa un sistema de login con 3 intentos antes de cambiar el estado del usuario a "INACTIVO".
Proveedores
  Registrar Proveedores: Permite dar de alta a proveedores, asociándolos a categorías de productos según el anexo de Categoría de productos.
  Baja de Proveedores: Permite dar de baja a proveedores, cambiando su estado a "INACTIVO".
Productos
  Registrar Productos: Permite dar de alta productos asociados a proveedores y categorías.
  Alerta de Stock Crítico: Muestra una alerta en la pantalla principal para los perfiles de Supervisores y Administradores cuando un producto tiene un stock menor al 25%.
Ventas
  Registrar Ventas: Permite registrar ventas y muestra el remito valorizado por pantalla.
  Devolución de Venta: Permite la devolución de una venta.
Cliente
  Registrar Cliente:
  Permite dar de alta a nuevos clientes.
Modificar Cliente:
  Permite modificar la dirección, teléfono, email y estado de un cliente.
Reportes
  Stock Crítico: Muestra productos con un stock menor al 25%, organizado por categoría. Para Supervisores y Administradores, muestra un mensaje en el menú principal.
  Ventas por Vendedor: Muestra la cantidad de ventas y el monto total agrupado por mes.
  Productos Más Vendidos por Categoría: Muestra el producto con la mayor cantidad de ventas por categoría.
