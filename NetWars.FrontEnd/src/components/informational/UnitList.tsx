import React, { ReactNode, useEffect, useState } from 'react';
import { Unit } from '../../interfaces/units/Unit.ts';
import { useAuth } from '../identity/AuthProvider.tsx';

const UnitList: React.FC = (): ReactNode => {
	const [units, setUnits] = useState<Unit[]>([]);
	const [error, setError] = useState<Error | null>(null);
	const [loading, setLoading] = useState<boolean>(true);
	const { token } = useAuth();

	//TODO - limit this to when token is not null

	useEffect(() => {
		const fetchData = async (): Promise<void> => {
			try {
				const response = await fetch('https://localhost:7228/api/v1.0/Units', {
					method: 'GET',
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json',
						'Authorization': `Bearer ${token}`
					}
				});

				if (response.ok) {
					const data: Unit[] = await response.json();
					setUnits(data);
				}
			} catch (error) {
				setError(error as Error);
			} finally {
				setLoading(false);
			}
		};

		fetchData();
	}, [token]);

	if (loading) {
		return <div>Loading...</div>;
	}

	if (error) {
		return <div>Error: {error.message}</div>;
	}

	return (
		<div>
			<h1>Unit List</h1>
			<ul>
				{units.map(unit => (
					<li key={unit.id}>{unit.name}</li>
				))}
			</ul>
		</div>
	);
};

export default UnitList;