import { Button, Container, TextField } from '@mui/material';
import React, { FormEvent, ReactNode, useState } from 'react';
import { useAuth } from './AuthProvider.tsx';

const LoginForm: React.FC = (): ReactNode => {
	const [username, setUsername] = useState('');
	const [password, setPassword] = useState('');
	const { login } = useAuth();

	const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		const response = await fetch('https://localhost:7228/api/v1.0/Token', {
			method: 'POST',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				email: username,
				password: password
			})
		});

		if (response.ok) {
			const data = await response.json();
			if (data.token) {
				login(data.token);
			} else {
				console.error('Token not found in response');
			}
		} else {
			console.error('Failed to login');
		}
	}

	return (

		<Container>
			<form id='login' onSubmit={handleSubmit}>
				<TextField id='Username' label='Username' name='Email' value={username} variant='outlined' required onChange={(e) => setUsername(e.target.value)} />
				<TextField id='Password' label='Password' name='Password' value={password} variant='outlined' required onChange={(e) => setPassword(e.target.value)} />
				<Button type='submit'>Login</Button>
			</form>
		</Container>
	)
}

export default LoginForm;