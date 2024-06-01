using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Backend.Core;
/// <summary>
/// Модель токена
/// </summary>
/// <param name="Value"> Строка токена для доступа</param>
public record class Token(string Value);
