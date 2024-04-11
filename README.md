# Keels Supermarket Management System

This is a conceptual project for a supermarket management system for Keels, developed using **C#** and **MS SQL Server**. The system includes a **Point of Sale (POS)** system, an **Inventory Management** system, and a **Nexus Member Management** system.

## Features

### Account Types

The system supports two types of accounts:

1. **Admins**: Admins have access to a dashboard and can perform the following actions:
    - **Products**: Add, update, and delete products.
    - **Product Category**: Add, update, and delete product categories.
    - **Employee**: Add, update, and delete employee details.
    - **Nexus Membership**: Add, update, and delete Nexus memberships and calculate points.

![Screenshot 2024-03-25 104239](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/2484b8d8-4403-4a1c-9432-b3ae5e6e3316)
![Screenshot 2024-03-25 104313](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/9510646c-3a44-4a4e-80bd-f23868b22bfc)
![image](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/b9e67ec8-5928-40bd-b7ad-e3743664f6ee)
![image](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/c8cda8b4-d68d-45b9-8461-1546534051ad)

2. **Cashiers**: Cashiers have access to the POS with all capabilities including bill generation.

### Cashier POS

The Cashier POS has several features:

- **Registering New Members**: Cashiers can register new Nexus members at the checkout.
- **Handling Transactions**: The POS system can handle sales transactions, returns, and exchanges.
- **Payment Processing**: The system accepts multiple forms of payment and can handle split payments.
- **Discounts and Promotions**: The POS system automatically applies any active discounts or promotions.
- **Receipt Generation**: The system generates a receipt after every transaction.
- **Nexus Points Calculation**: The system automatically calculates the points earned on each purchase for Nexus members.
- **Product Lookup**: Cashiers can quickly look up products by their barcodes or search terms.
- **End of Day Reporting**: The system generates a report detailing the total sales, returns, and revenue for the day.

![Screenshot 2024-03-25 104425](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/225ab2c2-98cd-44c8-8729-cfeb686600db)
![Screenshot 2024-03-25 104503](https://github.com/RyanSilva2004/KEELS-Super-POS/assets/137909008/1ff4a0ef-97ea-4e26-bb67-cf130796af99)

### POS and Inventory Management System

The POS system is capable of handling all standard POS operations. The inventory management system helps keep track of all products in the supermarket.

### Nexus Member Management

The Nexus Member Management system allows admins to manage Nexus memberships and calculate points based on purchases.

## Technologies Used

- **C#**: Used for backend logic.
- **MS SQL Server**: Used for database management.


