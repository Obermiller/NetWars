import { Button } from '@mui/material';
import React from 'react';
import { useAuth } from './AuthProvider.tsx';

const LogoutButton: React.FC = () => {
	const { logout } = useAuth();

	return (
		<Button variant='outlined' onClick={() => logout()}>Logout</Button>
	);
}

export default LogoutButton;