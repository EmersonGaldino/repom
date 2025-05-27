CREATE TABLE department (
    id SERIAL PRIMARY KEY,
    description VARCHAR(255) NOT NULL,
    created_at TIMESTAMP ,
    updated_at TIMESTAMP
);

-- Job table
CREATE TABLE job (
    id SERIAL PRIMARY KEY,
    description VARCHAR(255) NOT NULL,
    salary NUMERIC(18,2) NOT NULL,
    start_date TIMESTAMP NOT NULL,
    end_date TIMESTAMP NOT NULL,
    department_id INTEGER NOT NULL REFERENCES department(id),
    created_at TIMESTAMP ,
    updated_at TIMESTAMP
);

-- Address table
CREATE TABLE address (
    id SERIAL PRIMARY KEY,
    street VARCHAR(255) NOT NULL,
    number VARCHAR(50) NOT NULL,
    city VARCHAR(100) NOT NULL,
    zip_code VARCHAR(8),
    complement VARCHAR(255),
    state CHAR(2) NOT NULL,
    created_at TIMESTAMP ,
    updated_at TIMESTAMP
);

-- Person table
CREATE TABLE person (
    id SERIAL PRIMARY KEY,
    full_name VARCHAR(255) NOT NULL,
    rg VARCHAR(20) NOT NULL,
    cpf VARCHAR(11) NOT NULL,
    birth_date TIMESTAMP ,
    address_id INTEGER REFERENCES address(id),
    job_id INTEGER REFERENCES job(id),
    created_at TIMESTAMP ,
    updated_at TIMESTAMP
);

-- Phone table
CREATE TABLE phone (
    id SERIAL PRIMARY KEY,
    number VARCHAR(11) NOT NULL,
    type VARCHAR(20) NOT NULL CHECK (type IN ('Mobile', 'Home')),
    person_id INTEGER NOT NULL REFERENCES person(id),
    created_at TIMESTAMP ,
    updated_at TIMESTAMP
);