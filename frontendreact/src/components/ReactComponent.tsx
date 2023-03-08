import React from 'react';

function ExpenseItem(props: any) {
	return (
		<h2>
			<p>Expense item:</p>
			<p>{props.expenseItem}</p>
			<p>{props.amount}</p>
		</h2>
	);
}
export default ExpenseItem;