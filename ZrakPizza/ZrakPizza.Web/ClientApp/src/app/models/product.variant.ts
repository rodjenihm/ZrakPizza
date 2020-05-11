import { ProductOption } from './product.option';

export interface ProductVariant {
  id: string;
  name: string;
  description: string;
  imageUrl: string;
  productOption: ProductOption;
}
