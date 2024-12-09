import './App.css'
import AuthModule from './identity/AuthModule.tsx';
import { AuthProvider } from './identity/AuthProvider.tsx';

function App() {
    return (
        <AuthProvider>
            <AuthModule />
        </AuthProvider>
    );
}

export default App