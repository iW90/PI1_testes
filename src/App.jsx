import React from 'react';
import Utils from './components/utils';

const App = () => {
		const [pagina, setPagina] = React.useState('home');

		const handleMenuClick = (pagina) => {
		  setPagina(pagina);
		};
	  
		return (
		  <div>
			<header>
			  <Navbar onMenuItemClick={handleMenuClick} />
			</header>
			<main>
			  <PageContent pagina={pagina} />
			</main>
			<footer>
				<Footer />
			</footer>
		  </div>
		);
	  }

export default App;
