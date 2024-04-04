import React from 'react';

function	Navbar() {
	const handleItemClick = (pagina) => {
		onMenuItemClick(pagina);
	  };
	
	  return (
		<nav id="top-navbar">
			<ul>
				<li onClick={() => handleItemClick('home')}>Home</li>
				<li onClick={() => handleItemClick('calc')}>Calculadora de Portas</li>
				<li onClick={() => handleItemClick('mngt')}>Gerenciador de Dispositivos</li>
				<li onClick={() => handleItemClick('srch')}>Busca de Dispositivos</li>
			</ul>
		</nav>
	);
}

export default Navbar;