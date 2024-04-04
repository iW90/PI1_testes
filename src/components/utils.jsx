import React, { useState } from 'react';

// Componente de Conteúdo
function PageContent({ pagina }) {
	if (pagina === 'home') {
	  return <HomePage />;
	} else if (pagina === 'calc') {
	  return <CalculatorPage />;
	} else if (pagina === 'mngt') {
	  return <ManagementPage />;
	} else if (pagina === 'srch') {
	  return <SearchPage />;
	}
  
	return null;
}



export default Utils;