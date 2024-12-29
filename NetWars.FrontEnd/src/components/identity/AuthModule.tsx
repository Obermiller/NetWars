import React from 'react';
import { useAuth } from './AuthProvider.tsx';
import LoginForm from './LoginForm.tsx';
import LogoutButton from './LogoutButton.tsx';

const AuthModule: React.FC = () => {
	const { token } = useAuth(); // Use the token from the context

	return (
		<div>
			{token === null ?
				<div>
					<h2>Please Log In</h2>
					<LoginForm />
				</div> :
				<div>
					<h2>Welcome Back!</h2>
					<LogoutButton />
				</div>
			}
		</div>
	);
};

export default AuthModule;