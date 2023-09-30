-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-09-2023 a las 06:24:08
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `db_pizzas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tb_pizzas`
--

CREATE TABLE `tb_pizzas` (
  `id` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `tamanio` varchar(50) NOT NULL,
  `gluten_checked` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tb_pizzas`
--

INSERT INTO `tb_pizzas` (`id`, `nombre`, `precio`, `tamanio`, `gluten_checked`) VALUES
(1, 'Margherita', 42.00, 'Small', 0),
(2, 'Pepperoni', 22.00, 'Small', 1),
(3, 'Hawaiana', 10.00, 'Small', 1),
(4, 'Cuatro Quesos', 20.00, 'Medium', 0),
(5, 'Vegetariana', 30.00, 'Medium', 0),
(12, 'prueba 3', 50.00, 'Medium', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tb_pizzas`
--
ALTER TABLE `tb_pizzas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tb_pizzas`
--
ALTER TABLE `tb_pizzas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
