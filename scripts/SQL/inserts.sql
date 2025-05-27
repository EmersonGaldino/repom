INSERT INTO public.address (id, street, number, city, zip_code, complement, state, created_at, updated_at) VALUES (1, '123 Main St', '456', 'New York', '12345678', 'Apt 9B', 'NY', '2025-05-27 01:50:41.748914', '-infinity');
INSERT INTO public.address (id, street, number, city, zip_code, complement, state, created_at, updated_at) VALUES (8, '123 Main St', '456', 'New York', '12345678', 'Apt 9B', 'NY', '2025-05-27 02:07:23.005289', '-infinity');

INSERT INTO public.job (id, description, salary, start_date, end_date, department_id, created_at, updated_at) VALUES (1, 'Software Developer', 7500.00, '2025-05-27 01:49:25.257000', '-infinity', 1, '2025-05-27 01:50:41.748959', '-infinity');
INSERT INTO public.job (id, description, salary, start_date, end_date, department_id, created_at, updated_at) VALUES (8, 'Software Developer', 7500.00, '2025-05-27 01:49:25.257000', '-infinity', 8, '2025-05-27 02:07:23.007360', '-infinity');

INSERT INTO public.department (id, description, created_at, updated_at) VALUES (1, 'IT', '2025-05-27 01:50:41.749004', '-infinity');

INSERT INTO public.phone (id, number, type, person_id, created_at, updated_at) VALUES (2, '12345678901', 'Mobile', 8, '2025-05-27 02:07:23.006717', '-infinity');
INSERT INTO public.phone (id, number, type, person_id, created_at, updated_at) VALUES (3, '1123456789', 'Home', 8, '2025-05-27 02:07:23.007047', '-infinity');

INSERT INTO public.person (id, full_name, rg, cpf, birth_date, address_id, job_id, created_at, updated_at) VALUES (8, 'John Doe', '123456789', '98765432100', '1980-05-27 01:49:25.257000', 8, 8, '2025-05-27 02:07:23.004435', '-infinity');
