import { ProductOption } from './product.option';

export interface Product {
  id: string;
  name: string;
  description: string;
  imageUrl: string;
  productOptions: ProductOption[];
}
