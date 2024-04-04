import React from 'react'

const PostDeviceForm = () => {
	<form>
		<Input id="deviceName" type="text" text="Nome:" />
		<Input id="deviceDescription" type="text" text="Descrição:" />
		<Input id="deviceAI" type="text" text="Quantidade de Entradas Analógicas:" />
		<Input id="deviceAO" type="text" text="Quantidade de Saídas Analógicas:" />
		<Input id="deviceDI" type="text" text="Quantidade de Entradas Digitais:" />
		<Input id="deviceDO" type="text" text="Quantidade de Saídas Digitais:" />

		<Button id="addDevice" text="Cadastrar Dispositivo" action="algumaFunction()"/>
	</form>
}

export default PostDeviceForm