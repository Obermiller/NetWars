import React, { ReactNode, createContext, useContext, useLayoutEffect, useState, Context } from 'react';

interface AuthContextType {
	token: string | null;
	login: (newToken: string) => void;
	logout: () => void;
}

interface AuthProviderProps {
	children: ReactNode;
}

// Create a context with a default value of null
const AuthContext: Context<AuthContextType | null> = createContext<AuthContextType | null>(null);

const useAuth = (): AuthContextType => {
	const authContext: AuthContextType | null = useContext(AuthContext);

	if (authContext === null) {
		throw new Error('useAuth must be used within an AuthProvider');
	}

	return authContext;
};

const AuthProvider: React.FC<AuthProviderProps> = ({ children }: AuthProviderProps) => {
	const [token, setToken] = useState<string | null>(null);

	useLayoutEffect(() => {
		const savedToken = localStorage.getItem('authToken');
		if (savedToken) {
			setToken(savedToken);
		}
	}, []);

	const login = (newToken: string) => {
		setToken(newToken);
		localStorage.setItem('authToken', newToken);
	};

	const logout = () => {
		setToken(null);
		localStorage.removeItem('authToken');
	};

	// Ensure the context provider is passed the correct shape
	const authContextValue = { token, login, logout };

	return (
		<AuthContext.Provider value={authContextValue}>
			{children}
		</AuthContext.Provider>
	);
};

export { AuthProvider, useAuth };