import './App.css'
import AuthModule from './components/identity/AuthModule.tsx';
import { AuthProvider } from './components/identity/AuthProvider.tsx';
import UnitList from './components/informational/UnitList.tsx';

function App() {
    return (
        <AuthProvider>
            <AuthModule />
            <UnitList />
        </AuthProvider>
    );
}

export default App